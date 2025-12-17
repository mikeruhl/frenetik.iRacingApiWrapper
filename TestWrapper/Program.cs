using Frenetik.iRacingApiWrapper;
using Frenetik.iRacingApiWrapper.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestWrapper;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddLogging(builder => builder.AddConsole());

        // Register your token provider as a singleton
        // This allows the token provider to maintain state (cached tokens, etc.)
        services.AddSingleton<ITokenProvider, SampleTokenProvider>();

        // Register the API service with token-based auth
        services.AddSingleton<IRacingApiService>(sp =>
        {
            var tokenProvider = sp.GetRequiredService<ITokenProvider>();
            var logger = sp.GetRequiredService<ILogger<IRacingApiService>>();
            return new IRacingApiService(tokenProvider, logger);
        });

        var provider = services.BuildServiceProvider();
        var apiService = provider.GetRequiredService<IRacingApiService>();

        // Use the API service
        var results = await apiService.GetSeriesStats();
        Console.WriteLine($"Series count: {results.Count}");
    }
}
