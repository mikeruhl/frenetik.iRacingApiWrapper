using Frenetik.iRacingApiWrapper.Config;
using Microsoft.Extensions.Logging;
using Polly;
using RestSharp;
using System.Net;

namespace Frenetik.iRacingApiWrapper.Service;

/// <summary>
/// Builds Polly retry policies based on configuration
/// </summary>
public static class RetryPolicyBuilder
{
    /// <summary>
    /// Creates a comprehensive retry policy that handles server errors, rate limiting, and service unavailability.
    /// Each error type respects its own retry count limit.
    /// </summary>
    public static IAsyncPolicy<RestResponse> BuildAuthenticationPolicy(
        RetryPolicySettings settings,
        ILogger logger)
    {
        settings.Validate();

        var rateLimitPolicy = BuildRateLimitPolicyCore<RestResponse>(settings, logger, "Authentication");
        var serviceUnavailablePolicy = BuildServiceUnavailablePolicyCore<RestResponse>(settings, logger, "Authentication");
        var serverErrorPolicy = BuildServerErrorPolicyCore<RestResponse>(settings, logger, "Authentication");

        return Policy.WrapAsync(rateLimitPolicy, serviceUnavailablePolicy, serverErrorPolicy);
    }

    /// <summary>
    /// Creates a comprehensive retry policy for regular API requests.
    /// Each error type respects its own retry count limit.
    /// </summary>
    public static IAsyncPolicy<RestResponse<T>> BuildApiPolicy<T>(
        RetryPolicySettings settings,
        ILogger logger)
    {
        settings.Validate();

        var rateLimitPolicy = BuildRateLimitPolicyCore<RestResponse<T>>(settings, logger, "API");
        var serviceUnavailablePolicy = BuildServiceUnavailablePolicyCore<RestResponse<T>>(settings, logger, "API");
        var serverErrorPolicy = BuildServerErrorPolicyCore<RestResponse<T>>(settings, logger, "API");

        return Policy.WrapAsync(rateLimitPolicy, serviceUnavailablePolicy, serverErrorPolicy);
    }

    private static IAsyncPolicy<TResponse> BuildRateLimitPolicyCore<TResponse>(
        RetryPolicySettings settings,
        ILogger logger,
        string requestType)
        where TResponse : RestResponseBase
    {
        if (settings.RateLimitRetryCount == 0)
        {
            return Policy.NoOpAsync<TResponse>();
        }

        return Policy<TResponse>
            .HandleResult(r => r.StatusCode == HttpStatusCode.TooManyRequests)
            .WaitAndRetryAsync(
                retryCount: settings.RateLimitRetryCount,
                sleepDurationProvider: (retryCount, response, context) =>
                    GetRateLimitDelay(response.Result, settings, logger),
                onRetryAsync: async (response, timeSpan, retryCount, context) =>
                {
                    logger.LogWarning(
                        $"{requestType} request rate limited (429). " +
                        $"Waiting {timeSpan.TotalSeconds:F1}s before retry attempt {retryCount}/{settings.RateLimitRetryCount}");
                    await Task.CompletedTask;
                });
    }

    private static IAsyncPolicy<TResponse> BuildServiceUnavailablePolicyCore<TResponse>(
        RetryPolicySettings settings,
        ILogger logger,
        string requestType)
        where TResponse : RestResponseBase
    {
        if (settings.ServiceUnavailableRetryCount == 0)
        {
            // Return a no-op policy if retries are disabled
            return Policy.NoOpAsync<TResponse>();
        }

        return Policy<TResponse>
            .HandleResult(r => r.StatusCode == HttpStatusCode.ServiceUnavailable)
            .WaitAndRetryAsync(
                retryCount: settings.ServiceUnavailableRetryCount,
                sleepDurationProvider: (retryCount, response, context) =>
                    TimeSpan.FromSeconds(settings.ServiceUnavailableDelaySeconds),
                onRetryAsync: async (response, timeSpan, retryCount, context) =>
                {
                    logger.LogWarning(
                        $"{requestType} request service unavailable (503). " +
                        $"Waiting {timeSpan.TotalSeconds:F1}s before retry attempt {retryCount}/{settings.ServiceUnavailableRetryCount}");
                    await Task.CompletedTask;
                });
    }

    private static IAsyncPolicy<TResponse> BuildServerErrorPolicyCore<TResponse>(
        RetryPolicySettings settings,
        ILogger logger,
        string requestType)
        where TResponse : RestResponseBase
    {
        if (settings.ServerErrorRetryCount == 0)
        {
            return Policy.NoOpAsync<TResponse>();
        }

        return Policy<TResponse>
            .HandleResult(r => (int)r.StatusCode >= 500 || r.StatusCode == 0) 
            .WaitAndRetryAsync(
                retryCount: settings.ServerErrorRetryCount,
                sleepDurationProvider: (retryCount, response, context) =>
                    GetServerErrorDelay(retryCount, settings),
                onRetryAsync: async (response, timeSpan, retryCount, context) =>
                {
                    var statusDescription = response.Result.StatusCode == 0 ? "connection failure" : $"server error ({response.Result.StatusCode})";
                    logger.LogWarning(
                        $"{requestType} request {statusDescription}. " +
                        $"Waiting {timeSpan.TotalSeconds:F1}s before retry attempt {retryCount}/{settings.ServerErrorRetryCount}");
                    await Task.CompletedTask;
                });
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

    private static TimeSpan GetServerErrorDelay(int retryCount, RetryPolicySettings settings)
    {
        // Exponential backoff for server errors (base * 2^retry)
        // e.g., 200ms, 400ms, 800ms for retries 1, 2, 3
        return TimeSpan.FromMilliseconds(settings.ServerErrorBaseDelayMs * Math.Pow(2, retryCount));
    }
}
