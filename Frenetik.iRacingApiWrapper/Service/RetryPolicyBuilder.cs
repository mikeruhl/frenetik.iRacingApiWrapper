using Frenetik.iRacingApiWrapper.Config;
using Microsoft.Extensions.Logging;
using Polly;
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
    public static IAsyncPolicy<HttpResponseMessage> BuildPolicy(
        RetryPolicySettings settings,
        ILogger logger,
        string requestType = "API")
    {
        settings.Validate();

        var rateLimitPolicy = BuildRateLimitPolicyCore(settings, logger, requestType);
        var serviceUnavailablePolicy = BuildServiceUnavailablePolicyCore(settings, logger, requestType);
        var serverErrorPolicy = BuildServerErrorPolicyCore(settings, logger, requestType);

        return Policy.WrapAsync(rateLimitPolicy, serviceUnavailablePolicy, serverErrorPolicy);
    }

    private static IAsyncPolicy<HttpResponseMessage> BuildRateLimitPolicyCore(
        RetryPolicySettings settings,
        ILogger logger,
        string requestType)
    {
        if (settings.RateLimitRetryCount == 0)
        {
            return Policy.NoOpAsync<HttpResponseMessage>();
        }

        return Policy<HttpResponseMessage>
            .HandleResult(r =>
                r.StatusCode == HttpStatusCode.TooManyRequests || // Standard HTTP 429
                (r.StatusCode == HttpStatusCode.BadRequest && IsUnauthorizedClientError(r))) // iRacing's 400 + Retry-After
            .WaitAndRetryAsync(
                retryCount: settings.RateLimitRetryCount,
                sleepDurationProvider: (retryCount, response, context) =>
                    GetRateLimitDelay(response.Result, settings, logger),
                onRetryAsync: async (response, timeSpan, retryCount, context) =>
                {
                    var statusDesc = response.Result.StatusCode == HttpStatusCode.TooManyRequests
                        ? "rate limited (429)"
                        : "rate limited (400 + Retry-After)";
                    logger.LogWarning(
                        $"{requestType} request {statusDesc}. " +
                        $"Waiting {timeSpan.TotalSeconds:F1}s before retry attempt {retryCount}/{settings.RateLimitRetryCount}");

                    // Dispose the failed response to free resources
                    response.Result?.Dispose();
                    await Task.CompletedTask;
                });
    }

    private static bool IsUnauthorizedClientError(HttpResponseMessage response)
    {
        // iRacing uses 400 BadRequest + Retry-After header to indicate rate limiting
        // Per iRacing docs: https://oauth.iracing.com/oauth2/book/token_endpoint.html
        // "If the client exceeds the rate limit, the server will respond with a 400 Bad Request
        // status code, an unauthorized_client error, and a Retry-After header"
        return response.Headers.RetryAfter != null;
    }

    private static IAsyncPolicy<HttpResponseMessage> BuildServiceUnavailablePolicyCore(
        RetryPolicySettings settings,
        ILogger logger,
        string requestType)
    {
        if (settings.ServiceUnavailableRetryCount == 0)
        {
            // Return a no-op policy if retries are disabled
            return Policy.NoOpAsync<HttpResponseMessage>();
        }

        return Policy<HttpResponseMessage>
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

                    // Dispose the failed response to free resources
                    response.Result?.Dispose();
                    await Task.CompletedTask;
                });
    }

    private static IAsyncPolicy<HttpResponseMessage> BuildServerErrorPolicyCore(
        RetryPolicySettings settings,
        ILogger logger,
        string requestType)
    {
        if (settings.ServerErrorRetryCount == 0)
        {
            return Policy.NoOpAsync<HttpResponseMessage>();
        }

        return Policy<HttpResponseMessage>
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

                    // Dispose the failed response to free resources
                    response.Result?.Dispose();
                    await Task.CompletedTask;
                });
    }

    private static TimeSpan GetRateLimitDelay(
        HttpResponseMessage response,
        RetryPolicySettings settings,
        ILogger logger)
    {
        // Check for Retry-After header (iRacing's rate limiting)
        if (response.Headers.RetryAfter != null)
        {
            if (response.Headers.RetryAfter.Delta.HasValue)
            {
                var retryAfterSeconds = (int)response.Headers.RetryAfter.Delta.Value.TotalSeconds;
                logger.LogInformation($"Retry-After header found: {retryAfterSeconds} seconds");
                return TimeSpan.FromSeconds(retryAfterSeconds);
            }
            else if (response.Headers.RetryAfter.Date.HasValue)
            {
                var waitTime = response.Headers.RetryAfter.Date.Value - DateTimeOffset.UtcNow;
                if (waitTime > TimeSpan.Zero)
                {
                    logger.LogInformation($"Retry-After date found: {response.Headers.RetryAfter.Date.Value:u}");
                    return waitTime;
                }
            }
        }

        // Check for X-RateLimit-Reset header (alternative rate limit format)
        if (response.Headers.TryGetValues("X-RateLimit-Reset", out var resetValues))
        {
            var resetTime = resetValues.FirstOrDefault();
            if (resetTime != null && int.TryParse(resetTime, out var resetTimeSeconds))
            {
                var resetTimeUtc = DateTimeOffset.FromUnixTimeSeconds(resetTimeSeconds);
                var waitTime = resetTimeUtc - DateTimeOffset.UtcNow;

                if (waitTime > TimeSpan.Zero)
                {
                    logger.LogInformation($"X-RateLimit-Reset header found: {resetTimeUtc:u}");
                    return waitTime;
                }
            }
        }

        logger.LogInformation("No rate limit headers found, using default delay");
        return TimeSpan.FromSeconds(settings.RateLimitDefaultDelaySeconds);
    }

    private static TimeSpan GetServerErrorDelay(int retryCount, RetryPolicySettings settings)
    {
        // Exponential backoff for server errors (base * 2^retry)
        // e.g., 200ms, 400ms, 800ms for retries 1, 2, 3
        return TimeSpan.FromMilliseconds(settings.ServerErrorBaseDelayMs * Math.Pow(2, retryCount));
    }
}
