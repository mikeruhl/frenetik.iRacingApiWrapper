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

## Test Project

There is a test project called TestWrapper that shows how to set this up in a console app.

## Notes

- Ensure you have the correct iRacing API credentials.
- Handle exceptions and errors appropriately in your application.
- Any suggestions on improving this project or the readme?  Submit an issue, thanks!