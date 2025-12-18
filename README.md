# Frenetik.iRacingApiWrapper

[![Version](https://img.shields.io/nuget/vpre/frenetik.iracingapiwrapper.svg)](https://www.nuget.org/packages/frenetik.iracingapiwrapper)
[![Downloads](https://img.shields.io/nuget/dt/frenetik.iracingapiwrapper.svg)](https://www.nuget.org/packages/frenetik.iracingapiwrapper)

## Overview

This is a wrapper for the iRacing API service written in C#.  It is still early in development.  Use at your own risk and please report issues so they can be fixed.  Thanks!

## Submitting Issues

There are periodic updates to the iRacing API and I do not know how to track these updates.  If you encounter any issues or have suggestions for improvements, please submit them via the GitHub issue tracker.

1. Go to the [Issues](https://github.com/mikeruhl/iRacingApiWrapper/issues) section of the repository.
2. Click on the `New Issue` button.
3. Provide a clear and descriptive title for your issue.
4. Fill out the issue template with as much detail as possible, including steps to reproduce the issue, expected behavior, and any relevant screenshots or logs.
5. Submit the issue.

# IRacingApiService

The `IRacingApiService` is a service for interfacing with the iRacing API. It uses authentication and logging mechanisms to provide a reliable and secure way to interact with iRacing data.

## Authentication

iRacing uses OAuth 2.0 bearer token authentication. This library provides a built-in `PasswordLimitedTokenProvider` for automated/headless applications, or you can implement your own custom token provider.

### Option 1: Using PasswordLimitedTokenProvider (Recommended for Automated Apps)

The `PasswordLimitedTokenProvider` is ideal for automated/headless applications that run on behalf of a registered user. This uses iRacing's Password Limited OAuth grant flow.

> **Note:** This grant is limited to 3 registered users per client. Contact iRacing to register your client and users.

#### 1. Configure OAuth Settings

Store your OAuth credentials securely using user secrets (recommended) or appsettings.json:

**Using User Secrets (Recommended for Development):**
```bash
dotnet user-secrets set "OAuth:ClientId" "your_client_id"
dotnet user-secrets set "OAuth:ClientSecret" "your_client_secret"
dotnet user-secrets set "OAuth:Username" "your.email@example.com"
dotnet user-secrets set "OAuth:Password" "your_password"
```

**Or in appsettings.json:**

> ⚠️ **WARNING**: Never commit credentials to source control! The example below is for reference only.
> Always use User Secrets for development or secure configuration providers (Azure Key Vault, environment variables, etc.) for production.

```json
{
  "OAuth": {
    "ClientId": "your_client_id",           // DO NOT commit real values
    "ClientSecret": "your_client_secret",   // DO NOT commit real values
    "Username": "your.email@example.com",   // DO NOT commit real values
    "Password": "your_password",            // DO NOT commit real values
    "Scope": "iracing.auth"
  }
}
```

#### 2. Register Services

```csharp
using Frenetik.iRacingApiWrapper;
using Frenetik.iRacingApiWrapper.Config;
using Frenetik.iRacingApiWrapper.Service;
using Microsoft.Extensions.DependencyInjection;

public void ConfigureServices(IServiceCollection services)
{
    // Configure the Password Limited token provider
    services.Configure<PasswordLimitedTokenProviderSettings>(
        Configuration.GetSection("OAuth"));

    // Register the token provider
    services.AddSingleton<ITokenProvider, PasswordLimitedTokenProvider>();

    // Register the API service
    services.AddSingleton<IRacingApiService>(sp =>
    {
        var tokenProvider = sp.GetRequiredService<ITokenProvider>();
        var logger = sp.GetRequiredService<ILogger<IRacingApiService>>();
        return new IRacingApiService(tokenProvider, logger);
    });

    services.AddLogging();
}
```

#### 3. Use the Service

```csharp
public class RacingController : ControllerBase
{
    private readonly IRacingApiService _racingApiService;

    public RacingController(IRacingApiService racingApiService)
    {
        _racingApiService = racingApiService;
    }

    public async Task<IActionResult> GetSeries()
    {
        var series = await _racingApiService.GetSeries();
        return Ok(series);
    }
}
```

#### Features

The `PasswordLimitedTokenProvider` automatically handles:
- ✅ Secret masking using iRacing's SHA-256 algorithm
- ✅ Token caching and expiration
- ✅ Automatic token refresh using refresh tokens
- ✅ Rate limit detection and error handling
- ✅ Thread-safe token management

### Option 2: Custom ITokenProvider Implementation

For web applications with multiple users or custom OAuth flows, implement `ITokenProvider`:

```csharp
using Frenetik.iRacingApiWrapper.Service;

public class MyTokenProvider : ITokenProvider
{
    private string? _cachedToken;
    private DateTime _tokenExpiry;

    public async Task<string> GetTokenAsync()
    {
        // Return cached token if still valid
        if (!string.IsNullOrEmpty(_cachedToken) && DateTime.UtcNow < _tokenExpiry)
        {
            return _cachedToken;
        }

        // Implement your OAuth flow here
        // For Authorization Code flow, handle redirects and token exchange
        // For other flows, use your preferred OAuth library

        return _cachedToken;
    }
}
```

Then register your custom provider:

```csharp
services.AddSingleton<ITokenProvider, MyTokenProvider>();
services.AddSingleton<IRacingApiService>(sp =>
{
    var tokenProvider = sp.GetRequiredService<ITokenProvider>();
    var logger = sp.GetRequiredService<ILogger<IRacingApiService>>();
    return new IRacingApiService(tokenProvider, logger);
});
```

### Additional Resources

- [iRacing OAuth Overview](https://oauth.iracing.com/oauth2/book/auth_overview.html)
- [Password Limited Flow Documentation](https://oauth.iracing.com/oauth2/book/password_limited_flow.html)
- [Authorization Code Flow](https://oauth.iracing.com/oauth2/book/authorize_endpoint.html)

## Retry Policy Configuration

The wrapper includes configurable retry policies for handling transient failures and rate limiting:

```json
{
    "IRacingDataSettings": {
        "BaseUrl": "https://members-ng.iracing.com/",
        "Username": "your_username",
        "Password": "your_password",
        "RetryPolicy": {
            "ServerErrorRetryCount": 3,
            "ServerErrorBaseDelayMs": 200,
            "RateLimitRetryCount": 3,
            "RateLimitDefaultDelaySeconds": 15,
            "ServiceUnavailableRetryCount": 0,
            "ServiceUnavailableDelaySeconds": 60
        }
    }
}
```

**Retry Policy Settings:**
- **ServerErrorRetryCount**: Number of retries for 5xx errors (default: 3)
- **ServerErrorBaseDelayMs**: Base delay for exponential backoff on 5xx errors (default: 200ms)
- **RateLimitRetryCount**: Number of retries for 429 errors (default: 3)
- **RateLimitDefaultDelaySeconds**: Default delay when rate limit reset header is not present (default: 15s)
- **ServiceUnavailableRetryCount**: Number of retries for 503 errors (default: 0, since iRacing maintenance can last hours)
- **ServiceUnavailableDelaySeconds**: Delay between 503 retries if enabled (default: 60s)

## Exception Handling

The wrapper throws `ErrorResponseException` for all API-related errors, including authentication failures and API request errors. This provides consistent error handling across the entire library.

### ErrorResponseException

Thrown when the API returns an error response during authentication or API requests. Contains detailed error information including the HTTP status code.

```csharp
try
{
    var results = await _racingApiService.GetResults(subSessionId, includeLicenses: true);
}
catch (ErrorResponseException ex)
{
    _logger.LogError("API error ({StatusCode}): {Error} - {Message}",
        ex.ResultCode, ex.Error, ex.Message);

    // Check specific status codes
    if (ex.ResultCode == HttpStatusCode.Unauthorized || ex.ResultCode == HttpStatusCode.Forbidden)
    {
        // Handle authentication errors (wrong credentials)
        // These are not retried - check your username/password
        _logger.LogError("Authentication failed. Please check your credentials.");
    }
    else if (ex.ResultCode == HttpStatusCode.NotFound)
    {
        // Handle resource not found
    }
    else if (ex.ResultCode == HttpStatusCode.ServiceUnavailable)
    {
        // iRacing is down for maintenance (503)
        // By default, no retries are attempted since maintenance can last hours
        _logger.LogWarning("iRacing service is currently unavailable");
        // Consider notifying users or scheduling a retry later
    }
    else if (ex.ResultCode == HttpStatusCode.TooManyRequests)
    {
        // Rate limited - already retried based on X-RateLimit-Reset header
        _logger.LogWarning("Rate limit exceeded after retries");
    }
}
```

**Properties:**
- `ResultCode` (HttpStatusCode): The HTTP status code returned by the API
- `Error` (string): The error code or type from the API response
- `Message` (string): The error message describing what went wrong

**Common Status Codes:**
- `400 Bad Request`: Invalid parameters
- `401 Unauthorized`: Authentication failed (wrong credentials - not retried)
- `403 Forbidden`: Access denied (not retried)
- `404 Not Found`: Resource doesn't exist
- `429 Too Many Requests`: Rate limited (automatically retried with smart delay)
- `500 Internal Server Error`: Server error (automatically retried with exponential backoff)
- `503 Service Unavailable`: Maintenance window (not retried by default since maintenance can last hours)

## Test Project

There is a test project called TestWrapper that shows how to set this up in a console app.

## Notes

- Ensure you have the correct iRacing API credentials.
- Handle exceptions and errors appropriately in your application.
- Any suggestions on improving this project or the readme?  Submit an issue, thanks!