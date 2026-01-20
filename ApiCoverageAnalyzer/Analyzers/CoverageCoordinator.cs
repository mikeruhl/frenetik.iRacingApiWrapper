using ApiCoverageAnalyzer.Models;
using ApiCoverageAnalyzer.Reporters;
using Microsoft.Extensions.Logging;

namespace ApiCoverageAnalyzer.Analyzers;

/// <summary>
/// Coordinates all coverage analyzers and generates reports
/// </summary>
public class CoverageCoordinator
{
    private readonly EndpointCoverageAnalyzer _endpointAnalyzer;
    private readonly ParameterCoverageAnalyzer _parameterAnalyzer;
    private readonly ConsoleReporter _consoleReporter;
    private readonly ILogger<CoverageCoordinator> _logger;

    public CoverageCoordinator(
        EndpointCoverageAnalyzer endpointAnalyzer,
        ParameterCoverageAnalyzer parameterAnalyzer,
        ConsoleReporter consoleReporter,
        ILogger<CoverageCoordinator> logger)
    {
        _endpointAnalyzer = endpointAnalyzer;
        _parameterAnalyzer = parameterAnalyzer;
        _consoleReporter = consoleReporter;
        _logger = logger;
    }

    public async Task RunAsync(
        string mode,
        string? output,
        string format,
        bool checkThreshold,
        double endpointMin,
        double parameterMin)
    {
        _logger.LogInformation("Starting coverage analysis in {Mode} mode", mode);

        try
        {
            // Generate coverage report
            var report = new CoverageReport();

            if (mode == "quick")
            {
                // Run static analysis only
                _logger.LogInformation("Running static analysis (endpoints + parameters)...");
                await RunStaticAnalysisAsync(report);
            }
            else if (mode == "full")
            {
                // Run static + dynamic analysis
                _logger.LogInformation("Running full analysis (static + dynamic)...");
                await RunStaticAnalysisAsync(report);
                _logger.LogInformation("Dynamic analysis not yet implemented");
            }

            // Display report
            _consoleReporter.Report(report);

            // Check thresholds if requested
            if (checkThreshold)
            {
                var passed = CheckThresholds(report, endpointMin, parameterMin);
                Environment.ExitCode = passed ? 0 : 1;
            }

            _logger.LogInformation("Coverage analysis completed");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Coverage analysis failed");
            Environment.ExitCode = 1;
        }
    }

    private async Task RunStaticAnalysisAsync(CoverageReport report)
    {
        // Run endpoint coverage analysis
        var endpointResult = await _endpointAnalyzer.AnalyzeAsync();

        // Run parameter coverage analysis
        var parameterResults = await _parameterAnalyzer.AnalyzeAsync(endpointResult.MatchedEndpoints);

        // Populate report
        report.Summary.TotalEndpoints = endpointResult.TotalEndpoints;
        report.Summary.CoveredEndpoints = endpointResult.CoveredEndpoints;
        report.Summary.EndpointCoverage = endpointResult.CoveragePercentage;

        report.Summary.TotalParameters = parameterResults.Sum(p => p.TotalParameters);
        report.Summary.CoveredParameters = parameterResults.Sum(p => p.CoveredParameters);
        report.Summary.ParameterCoverage = report.Summary.TotalParameters > 0
            ? (double)report.Summary.CoveredParameters / report.Summary.TotalParameters * 100.0
            : 100.0;

        report.Summary.OverallCoverage = (report.Summary.EndpointCoverage + report.Summary.ParameterCoverage) / 2.0;

        report.MissingEndpoints = endpointResult.MissingEndpoints;
        report.EndpointResults = endpointResult.MatchedEndpoints
            .Select(e => new EndpointCoverageResult
            {
                Path = e.Key,
                Method = e.Value.MethodName,
                Status = CoverageStatus.Complete,
                ParameterResult = parameterResults.FirstOrDefault(p => p.EndpointPath == e.Key),
                ParameterCoverage = parameterResults.FirstOrDefault(p => p.EndpointPath == e.Key)?.CoveragePercentage ?? 0
            })
            .ToList();
    }

    private bool CheckThresholds(CoverageReport report, double endpointMin, double parameterMin)
    {
        var passed = true;

        if (report.Summary.EndpointCoverage < endpointMin)
        {
            _logger.LogError("Endpoint coverage {Coverage}% is below threshold {Threshold}%",
                report.Summary.EndpointCoverage, endpointMin);
            passed = false;
        }

        if (report.Summary.ParameterCoverage < parameterMin)
        {
            _logger.LogError("Parameter coverage {Coverage}% is below threshold {Threshold}%",
                report.Summary.ParameterCoverage, parameterMin);
            passed = false;
        }

        return passed;
    }
}
