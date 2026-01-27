using ApiCoverageAnalyzer.Analyzers;
using ApiCoverageAnalyzer.Comparers;
using ApiCoverageAnalyzer.Discovery;
using ApiCoverageAnalyzer.Reporters;
using ApiCoverageAnalyzer.Utilities;
using Frenetik.iRacingApiWrapper;
using Frenetik.iRacingApiWrapper.Config;
using Frenetik.iRacingApiWrapper.Service;
using GoFlag;
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
        // Parse command-line arguments with GoFlag
        var mode = Flag.String("mode", "quick", "Analysis mode (quick, full, detailed)");
        var output = Flag.String("output", "", "Output file path (optional)");
        var format = Flag.String("format", "console", "Output format (console, json)");
        var checkThreshold = Flag.Bool("check-threshold", false, "Fail if coverage thresholds are not met");
        var endpointMin = Flag.Float("endpoint-min", 0.0F, "Minimum endpoint coverage percentage");
        var parameterMin = Flag.Float("parameter-min", 0.0F, "Minimum parameter coverage percentage");
        var verbose = Flag.Bool("verbose", false, "Enable verbose logging");
        var verboseShorthand = Flag.Bool("v", false, "Enable verbose logging (shorthand)");

        Flag.Parse();

        var useVerbose = verbose.Value || verboseShorthand.Value;

        // Build host with DI
        var builder = Host.CreateApplicationBuilder(args);

        builder.Configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddUserSecrets<Program>();

        // Configure logging based on verbosity
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.SetMinimumLevel(useVerbose ? LogLevel.Debug : LogLevel.Information);

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

        // Get analyzer settings and apply defaults where needed
        var analyzerSettings = host.Services.GetRequiredService<IOptions<AnalyzerSettings>>().Value;

        var effectiveCheckThreshold = checkThreshold || analyzerSettings.FailOnThresholdViolation;
        var effectiveEndpointMin = endpointMin > 0 ? endpointMin : analyzerSettings.DefaultEndpointThreshold;
        var effectiveParameterMin = parameterMin > 0 ? parameterMin : analyzerSettings.DefaultParameterThreshold;
        var effectiveOutput = string.IsNullOrEmpty(output) ? null : output;

        // Run coverage analysis
        var coordinator = host.Services.GetRequiredService<CoverageCoordinator>();
        await coordinator.RunAsync(mode, effectiveOutput, format, effectiveCheckThreshold, effectiveEndpointMin, effectiveParameterMin);

        return Environment.ExitCode;
    }
}
