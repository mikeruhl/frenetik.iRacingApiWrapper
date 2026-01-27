using ApiCoverageAnalyzer.Analyzers;
using ApiCoverageAnalyzer.Utilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Runtime.Serialization;

namespace ApiCoverageAnalyzer.Comparers;

/// <summary>
/// Compares API parameters to wrapper method parameters
/// </summary>
public class ParameterComparer(
    NamingConventions naming,
    ILogger<ParameterComparer> logger,
    IOptions<AnalyzerSettings> settings)
{
    private const string NullableState = "nullable";
    private const string NonNullableState = "non-nullable";
    private readonly AnalyzerSettings _settings = settings.Value;

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

        // Validate each API parameter against method parameters
        ValidateApiParameters(apiParameters, methodParams, method, result);

        // Check for extra parameters in wrapper that don't exist in API
        ValidateExtraParameters(apiParameters, methodParams, method, result);

        return result;
    }

    /// <summary>
    /// Validate each API parameter against the method's parameters
    /// </summary>
    private void ValidateApiParameters(
        Dictionary<string, EndpointParameter> apiParameters,
        ParameterInfo[] methodParams,
        MethodInfo method,
        ParameterAnalysisResult result)
    {
        foreach (var (apiParamName, apiParam) in apiParameters)
        {
            var expectedParamName = naming.ToCamelCase(apiParamName);
            var matchingParam = FindMatchingParameter(methodParams, expectedParamName, apiParamName);

            if (matchingParam is null)
            {
                result.MissingParameters.Add(apiParamName);
                logger.LogWarning("Missing parameter {Parameter} in method {Method}",
                    apiParamName, method.Name);
                continue;
            }

            // Track the number of issues before validation
            var issuesBeforeValidation = result.TypeMismatches.Count;

            // Validate parameter properties
            ValidateTypeCompatibility(apiParam, matchingParam, apiParamName, result);
            ValidateNullableState(apiParam, matchingParam, apiParamName, result);
            ValidateRequiredOptional(apiParam, matchingParam, apiParamName);

            // Only count as covered if no new issues were found
            if (result.TypeMismatches.Count == issuesBeforeValidation)
            {
                result.CoveredParameters++;
            }
        }
    }

    /// <summary>
    /// Validate type compatibility between API and wrapper parameter
    /// </summary>
    private void ValidateTypeCompatibility(
        EndpointParameter apiParam,
        ParameterInfo matchingParam,
        string apiParamName,
        ParameterAnalysisResult result)
    {
        if (!TypeMapper.AreCompatible(apiParam.Type, matchingParam.ParameterType))
        {
            var wrapperTypeName = GetFriendlyTypeName(matchingParam.ParameterType);
            result.TypeMismatches.Add(new Models.TypeMismatch
            {
                Parameter = apiParamName,
                ApiType = apiParam.Type,
                WrapperType = wrapperTypeName
            });
            logger.LogWarning("Type mismatch for parameter {Parameter}: expected {Expected}, got {Actual}",
                apiParamName, apiParam.Type, wrapperTypeName);
        }
        else
        {
            // If it's an enum type, validate that all enum values appear in the API note
            ValidateEnumValues(matchingParam.ParameterType, apiParam.Note, apiParamName, result);
        }
    }

    /// <summary>
    /// Validate nullable state matches the required state
    /// </summary>
    private void ValidateNullableState(
        EndpointParameter apiParam,
        ParameterInfo matchingParam,
        string apiParamName,
        ParameterAnalysisResult result)
    {
        if (!TypeMapper.IsNullableStateCorrect(matchingParam.ParameterType, apiParam.Required))
        {
            var expectedState = apiParam.Required ? NonNullableState : NullableState;
            var actualState = (Nullable.GetUnderlyingType(matchingParam.ParameterType) is not null ||
                              !matchingParam.ParameterType.IsValueType) ? NullableState : NonNullableState;
            var wrapperTypeName = GetFriendlyTypeName(matchingParam.ParameterType);

            result.TypeMismatches.Add(new Models.TypeMismatch
            {
                Parameter = apiParamName,
                ApiType = $"{apiParam.Type} ({expectedState})",
                WrapperType = $"{wrapperTypeName} ({actualState})"
            });
            logger.LogWarning("Nullable mismatch for parameter {Parameter}: API expects {Expected} but wrapper has {Actual}",
                apiParamName, expectedState, actualState);
        }
    }

    /// <summary>
    /// Validate required vs optional parameter state
    /// </summary>
    private void ValidateRequiredOptional(
        EndpointParameter apiParam,
        ParameterInfo matchingParam,
        string apiParamName)
    {
        if (apiParam.Required && matchingParam.HasDefaultValue)
        {
            logger.LogWarning("Parameter {Parameter} is required in API but optional in wrapper",
                apiParamName);
        }
    }

    /// <summary>
    /// Validate extra parameters in wrapper that don't exist in API
    /// </summary>
    private void ValidateExtraParameters(
        Dictionary<string, EndpointParameter> apiParameters,
        ParameterInfo[] methodParams,
        MethodInfo method,
        ParameterAnalysisResult result)
    {
        foreach (var paramName in methodParams
            .Where(mp => !IsParameterInApi(mp, apiParameters))
            .Select(methodParam => methodParam.Name))
        {
            result.ExtraParameters.Add(paramName!);
            logger.LogWarning("Extra parameter {Parameter} in wrapper method {Method} not found in API",
                paramName, method.Name);
        }
    }

    /// <summary>
    /// Check if a method parameter exists in the API parameters
    /// </summary>
    private bool IsParameterInApi(ParameterInfo methodParam, Dictionary<string, EndpointParameter> apiParameters)
    {
        foreach (var (apiParamName, _) in apiParameters)
        {
            var expectedParamName = naming.ToCamelCase(apiParamName);
            var matchingParam = FindMatchingParameter(new[] { methodParam }, expectedParamName, apiParamName);

            if (matchingParam is not null)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Get a friendly type name for display (handles Nullable<T> properly)
    /// </summary>
    private static string GetFriendlyTypeName(Type type)
    {
        var underlyingType = Nullable.GetUnderlyingType(type);
        if (underlyingType is not null)
        {
            return $"{underlyingType.Name}?";
        }
        return type.Name;
    }

    /// <summary>
    /// Validate that enum values match the API documentation
    /// </summary>
    private void ValidateEnumValues(Type parameterType, string apiNote, string apiParamName, ParameterAnalysisResult result)
    {
        // Unwrap nullable types
        var actualType = Nullable.GetUnderlyingType(parameterType) ?? parameterType;

        if (!actualType.IsEnum)
            return;

        // Get all enum values and their EnumMember attribute values
        var enumValues = Enum.GetValues(actualType);
        var missingValues = new List<string>();

        foreach (var enumValue in enumValues)
        {
            var memberInfo = actualType.GetField(enumValue.ToString()!);
            if (memberInfo is null)
                continue;

            // Get the EnumMember attribute
            var enumMemberAttr = memberInfo.GetCustomAttribute<EnumMemberAttribute>();
            var expectedValue = enumMemberAttr?.Value ?? enumValue.ToString()!.ToLower();

            // Check if the value appears in the API note (case-insensitive)
            if (!apiNote.Contains(expectedValue, StringComparison.OrdinalIgnoreCase))
            {
                missingValues.Add(expectedValue);
            }
        }

        if (missingValues.Any())
        {
            result.TypeMismatches.Add(new Models.TypeMismatch
            {
                Parameter = apiParamName,
                ApiType = $"string (missing enum values in note: {string.Join(", ", missingValues)})",
                WrapperType = actualType.Name
            });
            logger.LogWarning("Enum validation failed for {Parameter}: values {Values} not found in API note",
                apiParamName, string.Join(", ", missingValues));
        }
    }

    /// <summary>
    /// Find a matching parameter with explicit mapping and fallback to exact match
    /// </summary>
    private ParameterInfo? FindMatchingParameter(ParameterInfo[] methodParams, string expectedParamName, string apiParamName)
    {
        // Strategy 1: Check explicit mappings first
        if (_settings.ParameterMappings.TryGetValue(apiParamName, out var mappedName))
        {
            var explicitMatch = methodParams.FirstOrDefault(p =>
                p.Name!.Equals(mappedName, StringComparison.OrdinalIgnoreCase));

            if (explicitMatch is not null)
            {
                logger.LogDebug("Matched {ApiParam} to {MethodParam} via explicit mapping",
                    apiParamName, explicitMatch.Name);
                return explicitMatch;
            }
        }

        // Strategy 2: Exact match (case-insensitive) using converted name
        var exactMatch = methodParams.FirstOrDefault(p =>
            p.Name!.Equals(expectedParamName, StringComparison.OrdinalIgnoreCase));

        if (exactMatch is not null)
            return exactMatch;

        return null;
    }
}
