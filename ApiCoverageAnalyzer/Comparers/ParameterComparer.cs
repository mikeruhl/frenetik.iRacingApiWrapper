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

            // Find matching method parameter
            var matchingParam = methodParams.FirstOrDefault(p =>
                p.Name!.Equals(expectedParamName, StringComparison.OrdinalIgnoreCase));

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

        return result;
    }
}
