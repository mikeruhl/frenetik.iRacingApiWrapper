using ApiCoverageAnalyzer.Discovery;
using ApiCoverageAnalyzer.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ApiCoverageAnalyzer.Comparers;

/// <summary>
/// Compares a live JSON API response against the corresponding C# model's mapped properties,
/// identifying any JSON fields that are not covered by a [JsonPropertyName] attribute.
/// </summary>
public class ResponseModelComparer(
    ModelPropertyExtractor extractor,
    ILogger<ResponseModelComparer> logger)
{
    private const int MaxDepth = 10;

    /// <summary>
    /// Finds JSON properties present in the response but not mapped in the model.
    /// </summary>
    /// <returns>Tuple of (missing properties with inferred types, total properties checked)</returns>
    public (List<MissingProperty> MissingProperties, int TotalProperties) Compare(JsonElement json, Type modelType)
    {
        var missing = new List<MissingProperty>();
        int total = 0;
        CompareRecursive(json, modelType, "", missing, ref total, 0);
        return (missing, total);
    }

    private void CompareRecursive(
        JsonElement json,
        Type modelType,
        string path,
        List<MissingProperty> missing,
        ref int total,
        int depth)
    {
        if (depth > MaxDepth) return;

        // Unwrap arrays — examine the first non-null element to infer structure
        if (json.ValueKind == JsonValueKind.Array)
        {
            foreach (var element in json.EnumerateArray())
            {
                if (element.ValueKind == JsonValueKind.Object)
                {
                    CompareRecursive(element, modelType, path, missing, ref total, depth);
                    break;
                }
            }
            return;
        }

        if (json.ValueKind != JsonValueKind.Object) return;

        var modelProps = extractor.GetJsonProperties(modelType);

        foreach (var jsonProp in json.EnumerateObject())
        {
            var propPath = string.IsNullOrEmpty(path) ? jsonProp.Name : $"{path}.{jsonProp.Name}";
            total++;

            if (!modelProps.TryGetValue(jsonProp.Name, out var nestedType))
            {
                logger.LogDebug("Missing model property: {Path}", propPath);
                missing.Add(new MissingProperty
                {
                    Path = propPath,
                    InferredType = InferType(jsonProp.Value, depth)
                });
            }
            else if (nestedType != null &&
                     (jsonProp.Value.ValueKind == JsonValueKind.Object ||
                      jsonProp.Value.ValueKind == JsonValueKind.Array))
            {
                // Recurse into nested complex types
                CompareRecursive(jsonProp.Value, nestedType, propPath, missing, ref total, depth + 1);
            }
        }
    }

    private static readonly string[] DateTimeFormats =
    [
        "yyyy-MM-ddTHH:mm:ssZ",
        "yyyy-MM-ddTHH:mm:ss.fffZ",
        "yyyy-MM-ddTHH:mm:ss.ffffffZ"
    ];

    private static string InferType(JsonElement element, int depth = 0) => element.ValueKind switch
    {
        JsonValueKind.String => IsDateTime(element.GetString()) ? "datetime" : "string",
        JsonValueKind.True or JsonValueKind.False => "bool",
        JsonValueKind.Null => "null",
        JsonValueKind.Object => depth < MaxDepth ? InferObjectType(element, depth) : "object",
        JsonValueKind.Array => InferArrayType(element, depth),
        JsonValueKind.Number => element.TryGetInt64(out _) ? "int" : "double",
        _ => "unknown"
    };

    private static string InferObjectType(JsonElement obj, int depth)
    {
        var props = obj.EnumerateObject()
            .Select(p => $"{p.Name}: {InferType(p.Value, depth + 1)}");
        return $"{{ {string.Join(", ", props)} }}";
    }

    private static bool IsDateTime(string? value) =>
        value is not null &&
        DateTime.TryParseExact(value, DateTimeFormats,
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.AssumeUniversal, out _);

    private static string InferArrayType(JsonElement array, int depth)
    {
        foreach (var element in array.EnumerateArray())
        {
            if (element.ValueKind != JsonValueKind.Null)
                return $"{InferType(element, depth)}[]";
        }
        return "array";
    }
}
