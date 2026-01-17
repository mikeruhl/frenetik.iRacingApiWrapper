# Frenetik.iRacingApiWrapper

[![Version](https://img.shields.io/nuget/vpre/frenetik.iracingapiwrapper.svg)](https://www.nuget.org/packages/frenetik.iracingapiwrapper)
[![Downloads](https://img.shields.io/nuget/dt/frenetik.iracingapiwrapper.svg)](https://www.nuget.org/packages/frenetik.iracingapiwrapper)

A comprehensive C# wrapper for the iRacing API with built-in OAuth 2.0 authentication, automatic token refresh, retry policies, and support for both single-user and multi-user scenarios.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Quick Start](#quick-start)
- [Authentication Patterns](#authentication-patterns)
- [Configuration](#configuration)
- [Example Projects](#example-projects)
- [Contributing](#contributing)
- [Additional Resources](#additional-resources)

## Features

- ✅ **OAuth 2.0 Authentication** - Built-in support for iRacing's Password Limited grant flow
- ✅ **Automatic Token Management** - Token caching, refresh, and expiration handling
- ✅ **Multi-User Support** - Per-request token context for HTTP servers with multiple users
- ✅ **Retry Policies** - Configurable retry logic for transient failures and rate limiting
- ✅ **Secret Masking** - Automatic credential masking using iRacing's SHA-256 algorithm
- ✅ **Type-Safe API** - Strongly-typed models for all iRacing API endpoints
- ✅ **Thread-Safe** - Safe for concurrent use in multi-threaded applications
- ✅ **Comprehensive Documentation** - Full XML documentation for IntelliSense support
- ✅ **Mixed Authentication** - Support for both single-user and multi-user patterns simultaneously (.NET 8+)

## Prerequisites

- **.NET 8.0** or **.NET 10.0**
- **iRacing OAuth Credentials** - Register your application at [iRacing OAuth](https://oauth.iracing.com)

## Installation

```bash
dotnet add package Frenetik.iRacingApiWrapper
```

## Quick Start

```csharp
using Frenetik.iRacingApiWrapper;
using Frenetik.iRacingApiWrapper.Config;
using Frenetik.iRacingApiWrapper.Service;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Configure OAuth credentials
services.Configure<PasswordLimitedTokenProviderSettings>(options =>
{
    options.ClientId = "your_client_id";
    options.ClientSecret = "your_client_secret";
    options.Username = "your.email@example.com";
    options.Password = "your_password";
});

// Register services
services.AddHttpClient(IRacingApiService.HttpClientName)
    .AddHttpMessageHandler<PasswordLimitedTokenHandler>();

services.AddTransient<PasswordLimitedTokenHandler>();
services.AddSingleton<ITokenProvider, PasswordLimitedTokenProvider>();
services.AddSingleton<IIRacingApiService, IRacingApiService>();
services.AddLogging();

// Use the API
var provider = services.BuildServiceProvider();
var api = provider.GetRequiredService<IIRacingApiService>();

var series = await api.GetSeries();
Console.WriteLine($"Found {series.Count()} series");
```

> ⚠️ **SECURITY**: Never commit credentials to source control! Use User Secrets for development or secure configuration providers (Azure Key Vault, environment variables) for production.

## Authentication Patterns

This library supports three authentication patterns. Choose based on your application architecture:

### Pattern 1: Single-User (PasswordLimited)

**Use Case:** Console apps, background jobs, or services that authenticate as one user.

**Setup:**

```bash
# Store credentials securely using user secrets
dotnet user-secrets set "OAuth:ClientId" "your_client_id"
dotnet user-secrets set "OAuth:ClientSecret" "your_client_secret"
dotnet user-secrets set "OAuth:Username" "your.email@example.com"
dotnet user-secrets set "OAuth:Password" "your_password"
```

```csharp
services.Configure<PasswordLimitedTokenProviderSettings>(
    Configuration.GetSection("OAuth"));

services.AddHttpClient(IRacingApiService.HttpClientName)
    .AddHttpMessageHandler<PasswordLimitedTokenHandler>();

services.AddTransient<PasswordLimitedTokenHandler>();
services.AddSingleton<ITokenProvider, PasswordLimitedTokenProvider>();
services.AddSingleton<IIRacingApiService, IRacingApiService>();
```

**Features:**
- ✅ Automatic token acquisition and refresh
- ✅ Secret masking using SHA-256
- ✅ Rate limit handling

**Full Example:** See [TestWrapper.PasswordLimited](TestWrapper.PasswordLimited/Program.cs)

> **Note:** Password Limited grant is limited to 3 users per client. Contact iRacing to register.

### Pattern 2: Multi-User (TokenContext)

**Use Case:** Web APIs handling requests from multiple users with different tokens.

**Setup:**

```csharp
services.AddSingleton<ITokenContext, TokenContext>();
services.AddHttpClient(IRacingApiService.HttpClientName)
    .AddHttpMessageHandler<TokenContextHandler>();

services.AddTransient<TokenContextHandler>();
services.AddSingleton<IIRacingApiService, IRacingApiService>();
```

**Usage:**

```csharp
public async Task<IActionResult> GetUserData(string userToken)
{
    using (_tokenContext.SetToken(userToken))
    {
        var series = await _api.GetSeries(); // Uses userToken
        return Ok(series);
    }
    // Token automatically cleared
}
```

**Features:**
- ✅ Thread-safe per-request tokens using `AsyncLocal`
- ✅ Automatic cleanup with `IDisposable`
- ✅ Support for nested scopes

**Important:** Always use `using` statements with `SetToken()` to ensure proper scoping.

**Full Example:** See [TestWrapper.Bearer](TestWrapper.Bearer/Program.cs)

### Pattern 3: Mixed Authentication (Keyed Services)

**New in v4.2.0** - Requires .NET 8.0+

**Use Case:** Applications that need BOTH single-user (background jobs) and multi-user (API requests) authentication.

**Setup:**

```csharp
// Register password-limited for background jobs
services.AddHttpClient("IRacing.PasswordLimited")
    .AddHttpMessageHandler(/* ... */);
services.AddKeyedSingleton<ITokenProvider, PasswordLimitedTokenProvider>("PasswordLimited");
services.AddKeyedSingleton<IIRacingApiService, IRacingApiService>("PasswordLimited", (sp, key) =>
    new IRacingApiService(/* ... */, "IRacing.PasswordLimited"));

// Register token-context for user requests
services.AddHttpClient("IRacing.TokenContext")
    .AddHttpMessageHandler(/* ... */);
services.AddKeyedSingleton<ITokenContext, TokenContext>("TokenContext");
services.AddKeyedSingleton<ITokenProvider, NoOpTokenProvider>("TokenContext");
services.AddKeyedSingleton<IIRacingApiService, IRacingApiService>("TokenContext", (sp, key) =>
    new IRacingApiService(/* ... */, "IRacing.TokenContext"));
```

**Usage:**

```csharp
// Background job - uses service credentials
public class DataSyncService
{
    public DataSyncService([FromKeyedServices("PasswordLimited")] IIRacingApiService api) { }
}

// User controller - uses per-request tokens
public class RacingController : ControllerBase
{
    public RacingController(
        [FromKeyedServices("TokenContext")] IIRacingApiService api,
        [FromKeyedServices("TokenContext")] ITokenContext tokenContext) { }
}
```

**Features:**
- ✅ Complete isolation between strategies
- ✅ No risk of token mixing
- ✅ Each has own HttpClient pipeline

**Full Example:** See [CHANGELOG.md](CHANGELOG.md#420) for complete setup code.

### Custom Token Provider

For custom OAuth flows (Authorization Code, Client Credentials, etc.), implement `ITokenProvider`:

```csharp
public class MyTokenProvider : ITokenProvider
{
    public async Task<string> GetTokenAsync(CancellationToken cancellationToken = default)
    {
        // Implement your OAuth flow
        return yourToken;
    }
}
```

## Configuration

### Retry Policy

Configure retry behavior for transient failures:

```csharp
services.Configure<IRacingDataSettings>(options =>
{
    options.RetryPolicy.ServerErrorRetryCount = 3;        // 5xx errors
    options.RetryPolicy.RateLimitRetryCount = 3;          // 429 errors
    options.RetryPolicy.ServiceUnavailableRetryCount = 0; // 503 errors (default: don't retry)
});
```

Or via `appsettings.json`:

```json
{
    "IRacingDataSettings": {
        "RetryPolicy": {
            "ServerErrorRetryCount": 3,
            "ServerErrorBaseDelayMs": 200,
            "RateLimitRetryCount": 3,
            "RateLimitDefaultDelaySeconds": 15
        }
    }
}
```

**Automatic Retry Behavior:**
- `401/403`: Not retried (auth issues)
- `429`: Retried with smart delay based on headers
- `500-502`: Retried with exponential backoff
- `503`: Not retried by default (maintenance can last hours)

### Exception Handling

All API errors throw `ErrorResponseException`:

```csharp
try
{
    var results = await _api.GetResults(subSessionId, includeLicenses: true);
}
catch (ErrorResponseException ex)
{
    _logger.LogError("API error ({StatusCode}): {Error} - {Message}",
        ex.ResultCode, ex.Error, ex.Message);
}
```

## Example Projects

### [TestWrapper.PasswordLimited](TestWrapper.PasswordLimited/Program.cs)

Demonstrates **Pattern 1** - single-user authentication with automatic token refresh.

**Run:**
```bash
cd TestWrapper.PasswordLimited
dotnet user-secrets set "OAuth:ClientId" "your_client_id"
dotnet user-secrets set "OAuth:ClientSecret" "your_client_secret"
dotnet user-secrets set "OAuth:Username" "your.email@example.com"
dotnet user-secrets set "OAuth:Password" "your_password"
dotnet run
```

### [TestWrapper.Bearer](TestWrapper.Bearer/Program.cs)

Demonstrates **Pattern 2** - per-request tokens for multi-user scenarios.

**Run:**
1. Obtain a bearer token via [Authorization Code Flow](https://oauth.iracing.com/oauth2/book/authorization_code_flow.html)
2. Set token in `userBearerToken` variable
3. `dotnet run`

## Contributing

Contributions welcome! Please:

1. **Report Issues**: Use the [GitHub issue tracker](https://github.com/mikeruhl/frenetik.iRacingApiWrapper/issues) with reproduction steps
2. **Submit PRs**: Fork → feature branch → tests → PR
3. **Follow Standards**: C# conventions, XML docs, unit tests, backward compatibility

## Additional Resources

- [iRacing OAuth Documentation](https://oauth.iracing.com/oauth2/book/auth_overview.html)
- [Password Limited Flow](https://oauth.iracing.com/oauth2/book/password_limited_flow.html)
- [Authorization Code Flow](https://oauth.iracing.com/oauth2/book/authorization_code_flow.html)
- [iRacing API Docs](https://members-ng.iracing.com/data/doc)
- [Changelog](CHANGELOG.md)
- [NuGet Package](https://www.nuget.org/packages/frenetik.iracingapiwrapper)

## License

MIT License - see [LICENSE](LICENSE) file for details.

---

**Disclaimer**: This is an unofficial wrapper for the iRacing API. Not affiliated with or endorsed by iRacing.com Motorsport Simulations, LLC.
