using ApiCoverageAnalyzer.Discovery;
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
    /// <returns>Tuple of (missing property paths, total properties checked)</returns>
    public (List<string> MissingProperties, int TotalProperties) Compare(JsonElement json, Type modelType)
    {
        var missing = new List<string>();
        int total = 0;
        CompareRecursive(json, modelType, "", missing, ref total, 0);
        return (missing, total);
    }

    private void CompareRecursive(
        JsonElement json,
        Type modelType,
        string path,
        List<string> missing,
        ref int total,
        int depth)
    {
        if (depth > MaxDepth) return;

        // Unwrap arrays — examine the first element to infer structure
        if (json.ValueKind == JsonValueKind.Array)
        {
            var enumerator = json.EnumerateArray();
            if (enumerator.MoveNext() && enumerator.Current.ValueKind == JsonValueKind.Object)
                CompareRecursive(enumerator.Current, modelType, path, missing, ref total, depth);
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
                missing.Add(propPath);
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
}
