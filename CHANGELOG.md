# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0] - 2025-12-11

### Added
- Configurable retry policies via `RetryPolicySettings` class
- Support for HTTP 503 (Service Unavailable) error handling
- `ServiceUnavailableException` for better error reporting when iRacing API is down
- Centralized `RetryPolicyBuilder` for consistent retry behavior across all API calls
- Retry policy configuration in `IRacingDataSettings.RetryPolicy`

### Changed
- Refactored retry logic to use Polly policies consistently across authentication and API requests
- Improved rate limit (429) handling with smart delay based on `X-RateLimit-Reset` header
- HTTP 503 errors now default to fail immediately (0 retries) since they typically indicate long maintenance windows
- Server error (5xx) retries now use exponential backoff
- Added .NET 10 support
- Removed .NET 6 support (EOL)

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

[1.1.0]: https://github.com/mikeruhl/frenetik.iRacingApiWrapper/compare/v1.0.2...v1.1.0
[1.0.2]: https://github.com/mikeruhl/frenetik.iRacingApiWrapper/compare/v0.9.2...v1.0.2
[0.9.2]: https://github.com/mikeruhl/frenetik.iRacingApiWrapper/compare/v0.9.1...v0.9.2
[0.9.1]: https://github.com/mikeruhl/frenetik.iRacingApiWrapper/releases/tag/v0.9.1
