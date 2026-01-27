using ApiCoverageAnalyzer.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiCoverageAnalyzer.Reporters;

/// <summary>
/// Generates JSON output for CI/CD integration
/// </summary>
public static class JsonReporter
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>
    /// Generate JSON report
    /// </summary>
    public static void GenerateReport(CoverageReport report, string? outputPath = null)
    {
        var json = JsonSerializer.Serialize(report, JsonOptions);

        if (string.IsNullOrEmpty(outputPath))
        {
            // Output to console
            Console.WriteLine(json);
        }
        else
        {
            // Write to file
            File.WriteAllText(outputPath, json);
            Console.WriteLine($"JSON report written to: {outputPath}");
        }
    }

    /// <summary>
    /// Generate summary JSON report with key metrics only
    /// </summary>
    public static void GenerateSummaryReport(CoverageReport report, string? outputPath = null)
    {
        var summary = new
        {
            timestamp = DateTime.UtcNow,
            coverage = new
            {
                endpoints = new
                {
                    total = report.Summary.TotalEndpoints,
                    covered = report.Summary.CoveredEndpoints,
                    missing = report.MissingEndpoints.Count,
                    percentage = report.Summary.EndpointCoverage
                },
                parameters = new
                {
                    total = report.Summary.TotalParameters,
                    covered = report.Summary.CoveredParameters,
                    percentage = report.Summary.ParameterCoverage
                },
                overall = new
                {
                    percentage = report.Summary.OverallCoverage
                }
            },
            issues = new
            {
                missingEndpoints = report.MissingEndpoints,
                parameterIssuesCount = report.EndpointResults
                    .Count(e => e.ParameterResult is not null &&
                               (e.ParameterResult.MissingParameters.Any() ||
                                e.ParameterResult.ExtraParameters.Any() ||
                                e.ParameterResult.TypeMismatches.Any()))
            }
        };

        var json = JsonSerializer.Serialize(summary, JsonOptions);

        if (string.IsNullOrEmpty(outputPath))
        {
            // Output to console
            Console.WriteLine(json);
        }
        else
        {
            // Write to file
            File.WriteAllText(outputPath, json);
            Console.WriteLine($"JSON summary report written to: {outputPath}");
        }
    }
}
