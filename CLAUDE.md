# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a C# wrapper library for the iRacing API, published as the NuGet package `Frenetik.iRacingApiWrapper`. The library provides strongly-typed access to iRacing's REST API with built-in authentication, rate limiting, and retry logic.

## Build Commands

```bash
# Build the entire solution
dotnet build

# Build in Release mode (generates NuGet package)
dotnet build -c Release

# Run tests
dotnet test

# Run the test wrapper console application
dotnet run --project TestWrapper
```

## Architecture

### Core Service Pattern

The `IRacingApiService` is the main entry point with 70+ methods for interacting with iRacing's API. It uses:
- **RestSharp** for HTTP operations
- **Polly** for retry policies (3 attempts with exponential backoff for 5xx errors)
- **Microsoft.Extensions.Options** for dependency injection configuration

### Authentication Flow

`IRacingAuthenticator` implements cookie-based authentication:
1. Credentials are hashed as `Base64(SHA256(password + username.ToLower()))`
2. Authentication cookie is managed automatically via `CookieContainer`
3. Tokens refresh transparently before requests
4. Rate limiting is handled automatically by detecting `429 Too Many Requests` responses and reading `X-RateLimit-Reset` headers

### Two-Phase Request Pattern

Many API methods use a two-phase approach controlled by the `followLink` parameter:
1. **Phase 1**: Authenticated request returns a `ResourceLink` with a temporary CDN URL
2. **Phase 2**: Anonymous request fetches actual data from the CDN

This delegates caching to iRacing's CDN infrastructure.

### ChunkInfo Pattern

iRacing returns large datasets via CDN with chunked files:
- Models implementing `IChunkInfo<T>` indicate paginated responses
- Use `GetChunkInfoData()` for synchronous retrieval
- Use `GetChunkInfoDataPageAsyncEnumerable()` for memory-efficient streaming

### Data Models

Models are organized in the `Models` folder by domain (League, Member, Result, Season, Series, Stats):
- All use `System.Text.Json` with `[JsonPropertyName]` attributes
- Enable nullable reference types
- Use init accessors for immutability where appropriate
- `SingleOrArrayConverter<T>` handles API inconsistencies where fields can be single objects or arrays

## XML Documentation

The project generates XML documentation for the NuGet package. All public types and members must have XML comments (warnings are generated for missing documentation). Per global CLAUDE.md instructions, comments should be used sparingly for implementation code, but XML comments for public APIs are required for this library.

## NuGet Package

The project auto-generates a NuGet package on build. Package metadata is in `Frenetik.iRacingApiWrapper.csproj`:
- Version, authors, description, tags
- Package icon (`icon.png`)
- README included in package
- Source Link enabled for debugging

## Testing

### Unit Tests

Tests are in `Frenetik.iRacingApiWrapper.Tests` using XUnit. The `TestWrapper` console application demonstrates real-world usage with user secrets for credentials.

### Snapshot Testing

`Frenetik.iRacingApiWrapper.SnapshotTests` provides automated API change detection:

**Purpose**: Track iRacing API evolution and detect breaking changes automatically.

**Key Commands**:
```bash
# Capture baseline snapshots of all API endpoints
dotnet test --filter "FullyQualifiedName=Frenetik.iRacingApiWrapper.SnapshotTests.ApiSnapshotTests.CaptureApiSnapshots"

# Compare current API responses with snapshots
dotnet test --filter "FullyQualifiedName=Frenetik.iRacingApiWrapper.SnapshotTests.ApiSnapshotTests.CompareApiSnapshots"
```

**How It Works**:
1. Uses reflection to discover all API methods on `IRacingApiService`
2. Invokes each method with default parameters
3. Captures JSON responses and saves to `snapshots/*.snapshot.json`
4. Compares new responses with saved snapshots to detect changes
5. Generates markdown reports detailing any differences

**Automation**:
- GitHub Actions workflow runs daily at 2 AM UTC
- Automatically creates issues when API changes are detected
- Commits updated snapshots to track API evolution over time

**Requirements**:
- Environment variables: `IRACING_USERNAME` and `IRACING_PASSWORD`
- iRacing account must have Legacy Authentication enabled

See `Frenetik.iRacingApiWrapper.SnapshotTests/README.md` for detailed documentation.

## iRacing API Notes

- iRacing requires "Legacy Authentication" to be enabled in account settings (https://oauth.iracing.com/accountmanagement/security/)
- API credentials are configured via `IRacingDataSettings` (BaseUrl, Username, Password)
- The API periodically changes without documentation - issues should be reported on GitHub
- CDN URLs returned by the API are time-limited and expire based on metadata
