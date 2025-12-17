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

iRacing uses OAuth 2.0 bearer token authentication. This library requires you to implement your own token provider using any OAuth library of your choice.

### 1. Implement ITokenProvider

Create a class that implements `ITokenProvider` to supply bearer tokens:

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

        // Use your preferred OAuth library to obtain a token
        // For example, using ROPC (Password Limited) flow:
        // var tokenResponse = await oauthClient.RequestPasswordTokenAsync(...);
        // _cachedToken = tokenResponse.AccessToken;
        // _tokenExpiry = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn - 60);

        return _cachedToken;
    }
}
```

See iRacing's OAuth documentation for details:
- [Auth Overview](https://oauth.iracing.com/oauth2/book/auth_overview.html)
- [Authorization Code Flow](https://oauth.iracing.com/oauth2/book/authorize_endpoint.html)
- [Password Limited Flow (ROPC)](https://oauth.iracing.com/oauth2/book/password_limited_flow.html)

### 2. Register services

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Register your token provider
    services.AddSingleton<ITokenProvider, MyTokenProvider>();

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

### 3. Use the service

```csharp
public class RacingController : ControllerBase
{
    private readonly IRacingApiService _racingApiService;

    public RacingController(IRacingApiService racingApiService)
    {
        _racingApiService = racingApiService;
    }

    // Your actions using IRacingApiService
}
```

## Test Project

There is a test project called TestWrapper that shows how to set this up in a console app.

## Notes

- Ensure you have the correct iRacing API credentials.
- Handle exceptions and errors appropriately in your application.
- Any suggestions on improving this project or the readme?  Submit an issue, thanks!