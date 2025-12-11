using Frenetik.iRacingApiWrapper.Config;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using RestSharp;
using System.Net;

namespace Frenetik.iRacingApiWrapper.Service;

/// <summary>
/// Builds Polly retry policies based on configuration
/// </summary>
public static class RetryPolicyBuilder
{
    /// <summary>
    /// Creates a comprehensive retry policy that handles server errors, rate limiting, and service unavailability
    /// </summary>
    public static AsyncRetryPolicy<RestResponse> BuildAuthenticationPolicy(
        RetryPolicySettings settings,
        ILogger logger)
    {
        return Policy<RestResponse>
            .HandleResult(r => ShouldRetry(r, settings))
            .WaitAndRetryAsync(
                retryCount: GetMaxRetryCount(settings),
                sleepDurationProvider: (retryCount, response, context) =>
                    GetRetryDelay(retryCount, response.Result, settings, logger),
                onRetryAsync: async (response, timeSpan, retryCount, context) =>
                {
                    logger.LogWarning(
                        $"Authentication request failed with status {response.Result.StatusCode}. " +
                        $"Waiting {timeSpan.TotalSeconds:F1}s before retry attempt {retryCount}");
                    await Task.CompletedTask;
                });
    }

    /// <summary>
    /// Creates a comprehensive retry policy for regular API requests
    /// </summary>
    public static AsyncRetryPolicy<RestResponse<T>> BuildApiPolicy<T>(
        RetryPolicySettings settings,
        ILogger logger)
    {
        return Policy<RestResponse<T>>
            .HandleResult(r => ShouldRetry(r, settings))
            .WaitAndRetryAsync(
                retryCount: GetMaxRetryCount(settings),
                sleepDurationProvider: (retryCount, response, context) =>
                    GetRetryDelay(retryCount, response.Result, settings, logger),
                onRetryAsync: async (response, timeSpan, retryCount, context) =>
                {
                    logger.LogWarning(
                        $"API request failed with status {response.Result.StatusCode}. " +
                        $"Waiting {timeSpan.TotalSeconds:F1}s before retry attempt {retryCount}");
                    await Task.CompletedTask;
                });
    }

    private static bool ShouldRetry(RestResponseBase response, RetryPolicySettings settings)
    {
        return response.StatusCode switch
        {
            HttpStatusCode.TooManyRequests => true,
            HttpStatusCode.ServiceUnavailable => settings.ServiceUnavailableRetryCount > 0,
            _ when (int)response.StatusCode >= 500 => true,
            _ when response.StatusCode == 0 => true, // Connection failure
            _ => false
        };
    }

    private static int GetMaxRetryCount(RetryPolicySettings settings)
    {
        return Math.Max(
            settings.ServerErrorRetryCount,
            Math.Max(settings.RateLimitRetryCount, settings.ServiceUnavailableRetryCount));
    }

    private static TimeSpan GetRetryDelay(
        int retryCount,
        RestResponseBase response,
        RetryPolicySettings settings,
        ILogger logger)
    {
        return response.StatusCode switch
        {
            HttpStatusCode.TooManyRequests => GetRateLimitDelay(response, settings, logger),
            HttpStatusCode.ServiceUnavailable => GetServiceUnavailableDelay(retryCount, settings),
            _ when (int)response.StatusCode == 0 => GetServerErrorDelay(retryCount, settings),
            _ => GetServerErrorDelay(retryCount, settings)
        };
    }

    private static TimeSpan GetRateLimitDelay(
        RestResponseBase response,
        RetryPolicySettings settings,
        ILogger logger)
    {
        var resetHeader = response.Headers?
            .FirstOrDefault(h => h.Name != null &&
                h.Name.Equals("X-RateLimit-Reset", StringComparison.OrdinalIgnoreCase));

        if (resetHeader?.Value?.ToString() is string resetTime &&
            int.TryParse(resetTime, out var resetTimeSeconds))
        {
            var resetTimeUtc = DateTimeOffset.FromUnixTimeSeconds(resetTimeSeconds);
            var waitTime = resetTimeUtc - DateTimeOffset.UtcNow;

            if (waitTime > TimeSpan.Zero)
            {
                logger.LogInformation($"Rate limit reset time found: {resetTimeUtc:u}");
                return waitTime;
            }
        }

        logger.LogInformation("No rate limit reset header found, using default delay");
        return TimeSpan.FromSeconds(settings.RateLimitDefaultDelaySeconds);
    }

    private static TimeSpan GetServiceUnavailableDelay(int retryCount, RetryPolicySettings settings)
    {
        // For 503, use a fixed delay
        return TimeSpan.FromSeconds(settings.ServiceUnavailableDelaySeconds);
    }

    private static TimeSpan GetServerErrorDelay(int retryCount, RetryPolicySettings settings)
    {
        return TimeSpan.FromMilliseconds(settings.ServerErrorBaseDelayMs * Math.Pow(2, retryCount));
    }
}
