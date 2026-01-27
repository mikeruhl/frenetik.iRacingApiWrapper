using ApiCoverageAnalyzer.Analyzers;
using ApiCoverageAnalyzer.Comparers;
using ApiCoverageAnalyzer.Discovery;
using ApiCoverageAnalyzer.Reporters;
using ApiCoverageAnalyzer.Utilities;
using Frenetik.iRacingApiWrapper;
using Frenetik.iRacingApiWrapper.Config;
using Frenetik.iRacingApiWrapper.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiCoverageAnalyzer;

class Program
{
    static async Task<int> Main(string[] args)
    {
        // Build host with DI
        var builder = Host.CreateApplicationBuilder(args);

        builder.Configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddUserSecrets<Program>();

        // Configure logging based on verbosity
        var verbose = HasArg(args, "--verbose") || HasArg(args, "-v");
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.SetMinimumLevel(verbose ? LogLevel.Debug : LogLevel.Information);

        // Register iRacing API service (following TestWrapper.Bearer pattern)
        builder.Services.AddHttpClient(IRacingApiService.HttpClientName)
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddHttpMessageHandler<PasswordLimitedTokenHandler>();
        builder.Services.AddSingleton<ITokenProvider, PasswordLimitedTokenProvider>();
        builder.Services.AddTransient<PasswordLimitedTokenHandler>();
        builder.Services.AddTransient<TokenContextHandler>();
        builder.Services.AddSingleton<IRacingApiService>();

        builder.Services.Configure<PasswordLimitedTokenProviderSettings>(options =>
        {
            options.ClientId = builder.Configuration["OAuth:ClientId"] ?? string.Empty;
            options.ClientSecret = builder.Configuration["OAuth:ClientSecret"] ?? string.Empty;
            options.Username = builder.Configuration["OAuth:Username"] ?? string.Empty;
            options.Password = builder.Configuration["OAuth:Password"] ?? string.Empty;
            options.Scope = builder.Configuration["OAuth:Scope"] ?? "iracing.auth";
        });

        // Configure analyzer settings
        builder.Services.Configure<AnalyzerSettings>(
            builder.Configuration.GetSection(nameof(AnalyzerSettings)));

        // Register discovery components
        builder.Services.AddSingleton<ApiEndpointDiscovery>();
        builder.Services.AddSingleton<MethodPathExtractor>();
        builder.Services.AddSingleton<WrapperMethodDiscovery>();
        builder.Services.AddSingleton<ModelDiscovery>();

        // Register comparers
        builder.Services.AddSingleton<EndpointComparer>();
        builder.Services.AddSingleton<ParameterComparer>();

        // Register analyzers
        builder.Services.AddSingleton<EndpointCoverageAnalyzer>();
        builder.Services.AddSingleton<ParameterCoverageAnalyzer>();
        builder.Services.AddSingleton<CoverageCoordinator>();

        // Register utilities
        builder.Services.AddSingleton<NamingConventions>();

        var host = builder.Build();

        // Get analyzer settings for defaults
        var analyzerSettings = host.Services.GetRequiredService<IOptions<AnalyzerSettings>>().Value;

        // Simple argument parsing
        var mode = GetArgValue(args, "--mode") ?? "quick";
        var output = GetArgValue(args, "--output");
        var format = GetArgValue(args, "--format") ?? "console";
        var checkThreshold = HasArg(args, "--check-threshold") || analyzerSettings.FailOnThresholdViolation;
        var endpointMin = double.Parse(GetArgValue(args, "--endpoint-min") ?? analyzerSettings.DefaultEndpointThreshold.ToString());
        var parameterMin = double.Parse(GetArgValue(args, "--parameter-min") ?? analyzerSettings.DefaultParameterThreshold.ToString());

        // Run coverage analysis
        var coordinator = host.Services.GetRequiredService<CoverageCoordinator>();
        await coordinator.RunAsync(mode, output, format, checkThreshold, endpointMin, parameterMin);

        return Environment.ExitCode;
    }

    static string? GetArgValue(string[] args, string argName)
    {
        for (int i = 0; i < args.Length - 1; i++)
        {
            if (args[i] == argName)
                return args[i + 1];
        }
        return null;
    }

    static bool HasArg(string[] args, string argName)
    {
        return args.Contains(argName);
    }
}
