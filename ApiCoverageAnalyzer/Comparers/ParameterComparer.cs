using ApiCoverageAnalyzer.Analyzers;
using ApiCoverageAnalyzer.Utilities;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ApiCoverageAnalyzer.Comparers;

/// <summary>
/// Compares API parameters to wrapper method parameters
/// </summary>
public class ParameterComparer
{
    private readonly NamingConventions _naming;
    private readonly TypeMapper _typeMapper;
    private readonly ILogger<ParameterComparer> _logger;

    public ParameterComparer(
        NamingConventions naming,
        TypeMapper typeMapper,
        ILogger<ParameterComparer> logger)
    {
        _naming = naming;
        _typeMapper = typeMapper;
        _logger = logger;
    }

    /// <summary>
    /// Compare API parameters to method parameters
    /// </summary>
    public ParameterAnalysisResult Compare(
        Dictionary<string, EndpointParameter> apiParameters,
        MethodInfo method)
    {
        var result = new ParameterAnalysisResult
        {
            TotalParameters = apiParameters.Count
        };

        var methodParams = method.GetParameters();

        foreach (var (apiParamName, apiParam) in apiParameters)
        {
            // Convert snake_case to camelCase for matching
            var expectedParamName = _naming.ToCamelCase(apiParamName);

            // Find matching method parameter with flexible matching
            var matchingParam = FindMatchingParameter(methodParams, expectedParamName, apiParamName);

            if (matchingParam == null)
            {
                result.MissingParameters.Add(apiParamName);
                _logger.LogWarning("Missing parameter {Parameter} in method {Method}",
                    apiParamName, method.Name);
                continue;
            }

            // Check type compatibility
            if (!_typeMapper.AreCompatible(apiParam.Type, matchingParam.ParameterType))
            {
                result.TypeMismatches.Add(new Models.TypeMismatch
                {
                    Parameter = apiParamName,
                    ApiType = apiParam.Type,
                    WrapperType = matchingParam.ParameterType.Name
                });
                _logger.LogWarning("Type mismatch for parameter {Parameter}: expected {Expected}, got {Actual}",
                    apiParamName, apiParam.Type, matchingParam.ParameterType.Name);
            }

            // Check nullable state matches required state
            if (!_typeMapper.IsNullableStateCorrect(matchingParam.ParameterType, apiParam.Required))
            {
                var expectedState = apiParam.Required ? "non-nullable" : "nullable";
                var actualState = (Nullable.GetUnderlyingType(matchingParam.ParameterType) != null || !matchingParam.ParameterType.IsValueType) ? "nullable" : "non-nullable";

                result.TypeMismatches.Add(new Models.TypeMismatch
                {
                    Parameter = apiParamName,
                    ApiType = $"{apiParam.Type} ({expectedState})",
                    WrapperType = $"{matchingParam.ParameterType.Name} ({actualState})"
                });
                _logger.LogWarning("Nullable mismatch for parameter {Parameter}: API expects {Expected} but wrapper has {Actual}",
                    apiParamName, expectedState, actualState);
            }

            // Check required vs optional
            if (apiParam.Required && matchingParam.HasDefaultValue)
            {
                result.RequiredOptionalMismatches.Add(apiParamName);
                _logger.LogWarning("Parameter {Parameter} is required in API but optional in wrapper",
                    apiParamName);
            }

            result.CoveredParameters++;
        }

        // Check for extra parameters (in wrapper but not in API)
        foreach (var methodParam in methodParams)
        {
            // Try to find this wrapper parameter in the API parameters
            var foundInApi = false;

            foreach (var (apiParamName, apiParam) in apiParameters)
            {
                var expectedParamName = _naming.ToCamelCase(apiParamName);
                var matchingParam = FindMatchingParameter(new[] { methodParam }, expectedParamName, apiParamName);

                if (matchingParam != null)
                {
                    foundInApi = true;
                    break;
                }
            }

            if (!foundInApi)
            {
                result.ExtraParameters.Add(methodParam.Name!);
                _logger.LogWarning("Extra parameter {Parameter} in wrapper method {Method} not found in API",
                    methodParam.Name, method.Name);
            }
        }

        return result;
    }

    /// <summary>
    /// Explicit mappings for API parameter names that don't follow standard conventions
    /// Key: API parameter name (snake_case), Value: Wrapper parameter name (camelCase)
    /// </summary>
    private static readonly Dictionary<string, string> ExplicitParameterMappings = new(StringComparer.OrdinalIgnoreCase)
    {
        // API uses abbreviated form, wrapper uses full form
        { "cust_id", "customerId" },

        // Add more explicit mappings here as needed
        // Example: { "api_param_name", "wrapperParamName" }
    };

    /// <summary>
    /// Find a matching parameter with explicit mapping and fallback to exact match
    /// </summary>
    private ParameterInfo? FindMatchingParameter(ParameterInfo[] methodParams, string expectedParamName, string apiParamName)
    {
        // Strategy 1: Check explicit mappings first
        if (ExplicitParameterMappings.TryGetValue(apiParamName, out var mappedName))
        {
            var explicitMatch = methodParams.FirstOrDefault(p =>
                p.Name!.Equals(mappedName, StringComparison.OrdinalIgnoreCase));

            if (explicitMatch != null)
            {
                _logger.LogDebug("Matched {ApiParam} to {MethodParam} via explicit mapping",
                    apiParamName, explicitMatch.Name);
                return explicitMatch;
            }
        }

        // Strategy 2: Exact match (case-insensitive) using converted name
        var exactMatch = methodParams.FirstOrDefault(p =>
            p.Name!.Equals(expectedParamName, StringComparison.OrdinalIgnoreCase));

        if (exactMatch != null)
            return exactMatch;

        return null;
    }
}
