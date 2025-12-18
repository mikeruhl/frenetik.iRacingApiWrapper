using Frenetik.iRacingApiWrapper;
using Frenetik.iRacingApiWrapper.Config;
using Frenetik.iRacingApiWrapper.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Build configuration from appsettings.json and user secrets
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets(typeof(Program).Assembly)
            .Build();

        var services = new ServiceCollection();

        services.AddLogging(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Information));

        // Configure the Password Limited token provider settings
        services.Configure<PasswordLimitedTokenProviderSettings>(options =>
        {
            // Load from configuration
            options.ClientId = config["OAuth:ClientId"] ?? string.Empty;
            options.ClientSecret = config["OAuth:ClientSecret"] ?? string.Empty;
            options.Username = config["OAuth:Username"] ?? string.Empty;
            options.Password = config["OAuth:Password"] ?? string.Empty;
            options.Scope = config["OAuth:Scope"] ?? "iracing.auth";
        });

        // Register the PasswordLimitedTokenProvider as the ITokenProvider
        services.AddSingleton<ITokenProvider, PasswordLimitedTokenProvider>();

        // Register the API service
        services.AddSingleton<IRacingApiService>(sp =>
        {
            var tokenProvider = sp.GetRequiredService<ITokenProvider>();
            var logger = sp.GetRequiredService<ILogger<IRacingApiService>>();
            return new IRacingApiService(tokenProvider, logger);
        });

        var provider = services.BuildServiceProvider();
        var apiService = provider.GetRequiredService<IRacingApiService>();

        // Use the API service
        Console.WriteLine("Fetching series stats...");
        var now = DateTime.UtcNow;
        var then = DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(30));
        var results = await apiService.GetResultsSearchSeries(startRangeBegin: then, startRangeEnd: now);
        var chunks = await apiService.GetChunkInfoData(results);
        Console.WriteLine($"Series count: {chunks.Count}");
    }
}

/*
 * Configuration example for appsettings.json or user secrets:
 *
 * {
 *   "OAuth": {
 *     "ClientId": "your_client_id",
 *     "ClientSecret": "your_client_secret",
 *     "Username": "your.email@example.com",
 *     "Password": "your_password",
 *     "Scope": "iracing.auth"
 *   }
 * }
 *
 * To set user secrets (recommended for development):
 * dotnet user-secrets set "OAuth:ClientId" "your_client_id"
 * dotnet user-secrets set "OAuth:ClientSecret" "your_client_secret"
 * dotnet user-secrets set "OAuth:Username" "your.email@example.com"
 * dotnet user-secrets set "OAuth:Password" "your_password"
 */
