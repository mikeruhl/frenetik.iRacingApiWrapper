using ApiCoverageAnalyzer.Models;
using ApiCoverageAnalyzer.Reporters;
using Microsoft.Extensions.Logging;

namespace ApiCoverageAnalyzer.Analyzers;

/// <summary>
/// Coordinates all coverage analyzers and generates reports
/// </summary>
public class CoverageCoordinator(
    EndpointCoverageAnalyzer endpointAnalyzer,
    ParameterCoverageAnalyzer parameterAnalyzer,
    ILogger<CoverageCoordinator> logger)
{
    public async Task RunAsync(
        string mode,
        string? output,
        string format,
        bool checkThreshold,
        double endpointMin,
        double parameterMin)
    {
        logger.LogInformation("Starting coverage analysis in {Mode} mode", mode);

        try
        {
            // Generate coverage report
            var report = new CoverageReport();

            if (mode == "quick")
            {
                // Run static analysis only
                logger.LogInformation("Running static analysis (endpoints + parameters)...");
                await RunStaticAnalysisAsync(report);
            }
            else if (mode == "full")
            {
                // Run static + dynamic analysis
                logger.LogInformation("Running full analysis (static + dynamic)...");
                await RunStaticAnalysisAsync(report);
                logger.LogInformation("Dynamic analysis not yet implemented");
            }

            // Display report based on format
            GenerateReport(report, format, output);

            // Check thresholds if requested
            if (checkThreshold)
            {
                var passed = CheckThresholds(report, endpointMin, parameterMin);
                Environment.ExitCode = passed ? 0 : 1;
            }

            logger.LogInformation("Coverage analysis completed");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Coverage analysis failed");
            Environment.ExitCode = 1;
        }
    }

    private async Task RunStaticAnalysisAsync(CoverageReport report)
    {
        // Run endpoint coverage analysis
        var endpointResult = await endpointAnalyzer.AnalyzeAsync();

        // Run parameter coverage analysis
        var parameterResults = await parameterAnalyzer.AnalyzeAsync(endpointResult.MatchedEndpoints);

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

    private void GenerateReport(CoverageReport report, string format, string? output)
    {
        switch (format.ToLowerInvariant())
        {
            case "json":
                JsonReporter.GenerateReport(report, output);
                break;
            case "json-summary":
                JsonReporter.GenerateSummaryReport(report, output);
                break;
            case "console":
            default:
                ConsoleReporter.Report(report);
                if (!string.IsNullOrEmpty(output))
                {
                    logger.LogWarning("Output path specified but console format does not support file output");
                }
                break;
        }
    }

    private bool CheckThresholds(CoverageReport report, double endpointMin, double parameterMin)
    {
        var passed = true;

        if (report.Summary.EndpointCoverage < endpointMin)
        {
            logger.LogError("Endpoint coverage {Coverage}% is below threshold {Threshold}%",
                report.Summary.EndpointCoverage, endpointMin);
            passed = false;
        }

        if (report.Summary.ParameterCoverage < parameterMin)
        {
            logger.LogError("Parameter coverage {Coverage}% is below threshold {Threshold}%",
                report.Summary.ParameterCoverage, parameterMin);
            passed = false;
        }

        return passed;
    }
}
