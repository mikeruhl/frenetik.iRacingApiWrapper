# Frenetik.iRacingApiWrapper

[![Version](https://img.shields.io/nuget/vpre/frenetik.iracingapiwrapper.svg)](https://www.nuget.org/packages/frenetik.iracingapiwrapper)
[![Downloads](https://img.shields.io/nuget/dt/frenetik.iracingapiwrapper.svg)](https://www.nuget.org/packages/frenetik.iracingapiwrapper)

## Overview

This is a wrapper for the iRacing API service written in C#.  It is still early in development.  Use at your own risk and please report issues so they can be fixed.  Thanks!

## Submitting Issues

Please report issues or suggestions via the [GitHub issue tracker](https://github.com/mikeruhl/iRacingApiWrapper/issues). Include steps to reproduce, expected behavior, and any relevant logs.

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
    "ClientId": "your_client_id",
    "ClientSecret": "your_client_secret",
    "Username": "your.email@example.com",
    "Password": "your_password",
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
    // Configure OAuth settings
    services.Configure<PasswordLimitedTokenProviderSettings>(
        Configuration.GetSection("OAuth"));

    // Register HTTP client with authentication handler
    services.AddHttpClient(IRacingApiService.HttpClientName)
        .SetHandlerLifetime(TimeSpan.FromMinutes(5))
        .AddHttpMessageHandler<BearerTokenDelegatingHandler>();

    // Register services
    services.AddTransient<BearerTokenDelegatingHandler>();
    services.AddSingleton<ITokenProvider, PasswordLimitedTokenProvider>();
    services.AddSingleton<IRacingApiService>();

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
// Register HTTP client with authentication handler
services.AddHttpClient(IRacingApiService.HttpClientName)
    .SetHandlerLifetime(TimeSpan.FromMinutes(5))
    .AddHttpMessageHandler<BearerTokenDelegatingHandler>();

// Register services with custom token provider
services.AddTransient<BearerTokenDelegatingHandler>();
services.AddSingleton<ITokenProvider, MyTokenProvider>();
services.AddSingleton<IRacingApiService>();
```

### Additional Resources

- [iRacing OAuth Overview](https://oauth.iracing.com/oauth2/book/auth_overview.html)
- [Password Limited Flow Documentation](https://oauth.iracing.com/oauth2/book/password_limited_flow.html)
- [Authorization Code Flow](https://oauth.iracing.com/oauth2/book/authorize_endpoint.html)

## Retry Policy Configuration

Configure retry behavior for transient failures and rate limiting:

```csharp
// Optional: Customize retry policies and base URL
services.Configure<IRacingDataSettings>(options =>
{
    options.BaseUrl = "https://members-ng.iracing.com"; // Optional: override base URL
    options.RetryPolicy.ServerErrorRetryCount = 3;
    options.RetryPolicy.ServerErrorBaseDelayMs = 200;
    options.RetryPolicy.RateLimitRetryCount = 3;
    options.RetryPolicy.RateLimitDefaultDelaySeconds = 15;
    options.RetryPolicy.ServiceUnavailableRetryCount = 0;
    options.RetryPolicy.ServiceUnavailableDelaySeconds = 60;
});
```

Or via appsettings.json:

```json
{
    "IRacingDataSettings": {
        "BaseUrl": "https://members-ng.iracing.com",
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

The wrapper throws `ErrorResponseException` for all API-related errors. The exception includes:
- `ResultCode` (HttpStatusCode): HTTP status code from the API
- `Error` (string): Error code or type
- `Message` (string): Detailed error message

```csharp
try
{
    var results = await _racingApiService.GetResults(subSessionId, includeLicenses: true);
}
catch (ErrorResponseException ex)
{
    _logger.LogError("API error ({StatusCode}): {Error} - {Message}",
        ex.ResultCode, ex.Error, ex.Message);

    // Handle specific cases as needed
    if (ex.ResultCode == HttpStatusCode.ServiceUnavailable)
    {
        // iRacing is down for maintenance
    }
}
```

**Automatic Retry Behavior:**
- `401/403`: Not retried (authentication issues)
- `429`: Retried with smart delay based on rate limit headers
- `500-502`: Retried with exponential backoff
- `503`: Not retried by default (maintenance can last hours)