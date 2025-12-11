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

## Enabling API Usage

iRacing adopted 2FA in 2024 and requires you to now opt-in to legacy authentication.

1. Goto https://oauth.iracing.com/accountmanagement/security/
2. At the bottom of the options, enable Legacy Authentication

## Usage

To use the `IRacingApiService`, follow these steps:

1. **Install necessary packages:**

   ```bash
   dotnet add package Microsoft.Extensions.Options
   dotnet add package Microsoft.Extensions.Logging
   ```

2. **Configure settings:**

   Create a configuration section in your `appsettings.json` file:

   ```json
   {
       "IRacingDataSettings": {
           "BaseUrl": "https://members-ng.iracing.com/",
           "Username": "your_username",
           "Password": "your_password"
       }
   }
   ```

3. **Register services:**

   In your `Startup.cs` or `Program.cs` file, register the necessary services:

   ```csharp
   public void ConfigureServices(IServiceCollection services)
   {
       services.Configure<IRacingDataSettings>(Configuration.GetSection("IRacingDataSettings"));
       services.AddSingleton<IRacingApiService>();
       services.AddLogging();
   }
   ```

4. **Use the service:**

   Inject and use the `IRacingApiService` in your application:

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