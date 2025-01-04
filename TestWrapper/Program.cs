using Frenetik.iRacingApiWrapper;
using Frenetik.iRacingApiWrapper.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets(typeof(Program).Assembly)
            .Build();
        services.AddLogging(builder => builder.AddConsole());
        services.AddSingleton<IRacingApiService>();
        services.Configure<IRacingDataSettings>(options =>
        {
            options.BaseUrl = config["BaseUrl"]!;
            options.Username = config["Username"]!;
            options.Password = config["Password"]!;
        });

        var provider = services.BuildServiceProvider();
        var apiService = provider.GetService<IRacingApiService>() ?? throw new InvalidOperationException("Services not set up correctly.");

        var results = await apiService.GetSeriesStats();


        Console.WriteLine(results.Count);
    }
}
