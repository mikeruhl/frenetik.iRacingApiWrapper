using ApiCoverageAnalyzer.Models;
using Microsoft.Extensions.Logging;

namespace ApiCoverageAnalyzer.Reporters;

/// <summary>
/// Reports coverage results to the console
/// </summary>
public class ConsoleReporter()
{
    public static void Report(CoverageReport report)
    {
        Console.WriteLine();
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("            API Coverage Analysis Report");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine();

        // Summary
        Console.WriteLine("Summary:");
        Console.WriteLine($"  Endpoint Coverage:        {report.Summary.CoveredEndpoints}/{report.Summary.TotalEndpoints} ({report.Summary.EndpointCoverage:F1}%) {GetStatusSymbol(report.Summary.EndpointCoverage)}");
        Console.WriteLine($"  Parameter Coverage:       {report.Summary.CoveredParameters}/{report.Summary.TotalParameters} ({report.Summary.ParameterCoverage:F1}%) {GetStatusSymbol(report.Summary.ParameterCoverage)}");
        Console.WriteLine($"  Overall Coverage:         {report.Summary.OverallCoverage:F1}% {GetStatusSymbol(report.Summary.OverallCoverage)}");
        Console.WriteLine();

        // Missing endpoints
        if (report.MissingEndpoints.Any())
        {
            Console.WriteLine($"Missing Endpoints ({report.MissingEndpoints.Count}):");
            foreach (var endpoint in report.MissingEndpoints)
            {
                Console.WriteLine($"  ✗ {endpoint}");
            }
            Console.WriteLine();
        }

        // Parameter issues (excluding skipped endpoints)
        var parameterIssues = report.EndpointResults
            .Where(e => e.ParameterResult is not null &&
                       !e.ParameterResult.IsSkipped &&
                       (e.ParameterResult.MissingParameters.Any() ||
                        e.ParameterResult.ExtraParameters.Any() ||
                        e.ParameterResult.TypeMismatches.Any() ||
                        e.ParameterResult.RequiredOptionalMismatches.Any()))
            .ToList();

        if (parameterIssues.Any())
        {
            Console.WriteLine($"Parameter Issues ({parameterIssues.Count} endpoints):");
            foreach (var endpoint in parameterIssues)
            {
                // Print endpoint path once at the beginning
                Console.WriteLine($"  ✗ {endpoint.Path}");

                if (endpoint.ParameterResult.MissingParameters.Any())
                {
                    foreach (var param in endpoint.ParameterResult.MissingParameters)
                    {
                        Console.WriteLine($"      - Missing parameter: {param}");
                    }
                }

                if (endpoint.ParameterResult.ExtraParameters.Any())
                {
                    foreach (var param in endpoint.ParameterResult.ExtraParameters)
                    {
                        Console.WriteLine($"      - Extra parameter: {param} (not in API)");
                    }
                }

                if (endpoint.ParameterResult.TypeMismatches.Any())
                {
                    foreach (var mismatch in endpoint.ParameterResult.TypeMismatches)
                    {
                        Console.WriteLine($"      - Type mismatch: {mismatch.Parameter} (expected: {mismatch.ApiType}, got: {mismatch.WrapperType})");
                    }
                }

                if (endpoint.ParameterResult.RequiredOptionalMismatches.Any())
                {
                    foreach (var param in endpoint.ParameterResult.RequiredOptionalMismatches)
                    {
                        Console.WriteLine($"      - Required/optional mismatch: {param}");
                    }
                }
            }
            Console.WriteLine();
        }

        // Final summary
        if (report.MissingEndpoints.Count == 0 && parameterIssues.Count == 0)
        {
            Console.WriteLine("✓ All endpoints and parameters are covered!");
        }
        else
        {
            Console.WriteLine($"Found {report.MissingEndpoints.Count} missing endpoints and {parameterIssues.Count} endpoints with parameter issues.");
        }

        Console.WriteLine();
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
    }

    private static string GetStatusSymbol(double coverage)
    {
        return coverage >= 100.0 ? "✓" :
               coverage >= 95.0 ? "⚠" :
               "✗";
    }
}
