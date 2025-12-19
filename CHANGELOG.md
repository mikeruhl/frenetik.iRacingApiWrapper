# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [4.0.0] - Unreleased

### Breaking Changes
- **RestSharp Removed**: Migrated from RestSharp to native HttpClient with HttpClientFactory
  - Better resource management and connection pooling
  - Simplified dependency injection
- **IRacingApiService Constructor Changes**: Complete signature redesign
  - Old (v3.x): `IRacingApiService(ITokenProvider tokenProvider)` with RestSharp
  - New (v4.x): `IRacingApiService(IHttpClientFactory httpClientFactory, IOptions<IRacingDataSettings>? settings, ILogger<IRacingApiService> logger)`
  - Authentication now handled via `BearerTokenDelegatingHandler` instead of being tied to RestSharp
  - Must register `IRacingApiService` through dependency injection (see Migration Guide below)

### Added
- `MaxParallelAssetRequests` setting in `IRacingDataSettings` (default: 10)
  - Limits concurrent asset downloads to prevent connection pool exhaustion and rate limiting
  - Configurable for different network conditions and rate limit requirements

### Changed
- HTTP client implementation migrated from RestSharp to native `HttpClient` with `IHttpClientFactory`
- Better error handling with improved error messages from API responses

### Fixed
- Unbounded parallelism in `GetAssets` method that could cause connection pool exhaustion when downloading many assets
- Response buffering to support retry policy synchronous reads
- Proper disposal of HTTP responses in retry policies to prevent resource leaks

### Migration Guide

#### Constructor Usage Changes

**Before (v3.x):**
```csharp
services.AddSingleton<ITokenProvider, PasswordLimitedTokenProvider>();
services.AddSingleton<IRacingApiService>(sp =>
{
    var tokenProvider = sp.GetRequiredService<ITokenProvider>();
    return new IRacingApiService(tokenProvider); // RestSharp-based
});
```

**After (v4.x):**
```csharp
// Configure OAuth settings (if not already done)
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
```

#### Key Changes
1. **No more RestSharp dependency** - Now uses native `HttpClient` for better performance
2. **IHttpClientFactory required** - Better resource management and connection pooling
3. **Authentication via delegating handler** - `BearerTokenDelegatingHandler` handles token injection
4. **Dependency injection required** - Constructor complexity makes DI the only practical approach

See README for complete setup instructions including user secrets configuration.

## [3.0.1] - 2025-12-18

### Fixed
- Fixed `GetChunkInfoData` incorrectly including Authorization header when fetching chunk data from AWS S3
  - Authorization headers are now only included for requests to the iRacing base URL
  - External URLs (e.g., `https://scorpio-assets.s3.amazonaws.com`) no longer receive authentication headers

## [3.0.0] - 2025-12-17

### Breaking Changes
- **OAuth 2.0 Migration**: Replaced legacy cookie-based authentication with OAuth 2.0 Password Limited grant type
  - `IRacingAuthenticator` (cookie-based) has been **removed** - use `BearerTokenDelegatingHandler` with `ITokenProvider` instead
  - `IRacingApiService` constructor now requires `IHttpClientFactory` and `ILogger` - authentication is handled via delegating handler
  - Configuration changes: `IRacingDataSettings.Username` and `IRacingDataSettings.Password` properties **removed**
- **Interface changes**: `ITokenProvider.GetTokenAsync()` now includes optional `CancellationToken` parameter
- **Migration required**: See README for updated OAuth configuration examples using `PasswordLimitedTokenProviderSettings`

### Added
- `ITokenProvider` interface for flexible OAuth token management
- `PasswordLimitedTokenProvider` - OAuth 2.0 Password Limited grant implementation with:
  - Automatic token caching and refresh
  - Proper resource disposal via `IDisposable`
  - Input validation for required configuration
  - Comprehensive error handling with detailed error messages
  - Cancellation token support for async operations
  - Uses `IHttpClientFactory` for proper HTTP client management
- `BearerTokenDelegatingHandler` for HttpClient OAuth integration
  - Intelligently adds authentication only to iRacing base URL requests
  - External URLs (S3, CDN) do not receive authentication headers
- `PasswordLimitedTokenProviderSettings` configuration class
- iRacing-specific secret masking algorithm (Base64-encoded SHA-256)
- Comprehensive unit test coverage (31 tests) for OAuth token provider
- CI/CD workflow with automated test execution
- Security warnings in README about credential storage
- HttpClient resource management improvements (proper disposal, response buffering)

### Changed
- Rate limiting detection now handles iRacing's specific implementation (400 + "unauthorized_client" + Retry-After header)
- Polly retry policies updated to respect `Retry-After` header for rate limiting
- Error messages now preserve full OAuth error response content for better debugging
- Token expiry calculations handle edge cases (tokens with < 60 second lifetime)
- JSON deserialization now case-insensitive for OAuth responses

### Fixed
- Resource leaks: `SemaphoreSlim` and `HttpClient` now properly disposed
- Error content preservation: All OAuth failures now include detailed error information
- Rate limit handling: Correctly interprets iRacing's 400 BadRequest as rate limiting (not authorization failure)
- Token expiry edge cases: Tokens with very short lifetimes no longer cause negative expiry times

### Technical Details
- OAuth tokens cached with 60-second safety buffer before expiration
- Automatic token refresh when access token expires but refresh token is still valid
- Falls back to password grant if refresh token is expired or unavailable
- Thread-safe token acquisition using `SemaphoreSlim`

### Migration Guide
**Before (v2.x):**
```csharp
services.AddSingleton<IRacingApiService>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<IRacingDataSettings>>().Value;
    return new IRacingApiService(settings.Username, settings.Password, settings);
});
```

**After (v3.x):**
```csharp
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
```

See README for complete setup instructions including user secrets configuration.

## [2.0.0] - 2025-12-11

### Breaking Changes
- **Constructor signature change**: `IRacingAuthenticator` now requires a `RetryPolicySettings` parameter. If you directly instantiate this class, update your code to pass retry settings.
- **Dropped .NET 6 support**: Minimum supported framework is now .NET 8.0. .NET 6 reached end-of-life in November 2024.
- **Exception handling**: Authentication failures now throw `ErrorResponseException` instead of `HttpRequestException`. Use `ex.ResultCode` to check specific status codes (401, 403, 429, 503, etc.).

### Added
- Configurable retry policies via `RetryPolicySettings` class
- Support for HTTP 503 (Service Unavailable) error handling with configurable retry behavior
- Centralized `RetryPolicyBuilder` for consistent retry behavior across all API calls
- Retry policy configuration in `IRacingDataSettings.RetryPolicy`
- .NET 10 support
- XML documentation for `ErrorResponseException`

### Changed
- Refactored retry logic to use Polly policies consistently across authentication and API requests
- Improved rate limit (429) handling with smart delay based on `X-RateLimit-Reset` header
- HTTP 503 errors now default to fail immediately (0 retries) since they typically indicate long maintenance windows
- Server error (5xx) retries now use exponential backoff

### Technical Details
- Rate limit retries: Up to 3 attempts with smart delay based on reset header (default 15s fallback)
- Server error retries: Up to 3 attempts with exponential backoff (200ms base delay)
- Service unavailable retries: Configurable (default 0 retries, 60s delay if enabled)

## [1.0.2] - 2025-06-28

### Changed
- Updated to .NET 8.0
- Deprecated club-related endpoints (iRacing 2025 Season 3 API changes)

## [0.9.1] - 2025-05-28

### Added
- Project initialization
- Basic API wrapper structure

[3.0.1]: https://github.com/mikeruhl/frenetik.iRacingApiWrapper/compare/v3.0.0...v3.0.1
[3.0.0]: https://github.com/mikeruhl/frenetik.iRacingApiWrapper/compare/v2.0.0...v3.0.0
[2.0.0]: https://github.com/mikeruhl/frenetik.iRacingApiWrapper/compare/v1.0.2...v2.0.0
[1.0.2]: https://github.com/mikeruhl/frenetik.iRacingApiWrapper/compare/v0.9.2...v1.0.2
[0.9.2]: https://github.com/mikeruhl/frenetik.iRacingApiWrapper/compare/v0.9.1...v0.9.2
[0.9.1]: https://github.com/mikeruhl/frenetik.iRacingApiWrapper/releases/tag/v0.9.1
