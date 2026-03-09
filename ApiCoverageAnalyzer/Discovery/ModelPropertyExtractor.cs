using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json.Serialization;

namespace ApiCoverageAnalyzer.Discovery;

/// <summary>
/// Extracts JSON property names and their corresponding C# types from model classes via reflection
/// </summary>
public class ModelPropertyExtractor(ILogger<ModelPropertyExtractor> logger)
{
    private static readonly HashSet<Type> LeafTypes =
    [
        typeof(string), typeof(object), typeof(Stream),
        typeof(DateTime), typeof(DateTimeOffset), typeof(Guid),
        typeof(TimeSpan)
    ];

    /// <summary>
    /// Extracts the leaf model type from a wrapper method's return type.
    /// E.g., Task&lt;IEnumerable&lt;SeriesSeasonsResult&gt;&gt; → SeriesSeasonsResult
    /// Returns null for non-inspectable types (Stream, primitives, dynamic, void).
    /// </summary>
    public Type? ExtractModelType(MethodInfo method)
    {
        var returnType = method.ReturnType;

        // Unwrap Task<T>
        if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
            returnType = returnType.GetGenericArguments()[0];
        else if (returnType == typeof(Task) || returnType == typeof(void))
            return null;

        returnType = UnwrapCollectionType(returnType);

        if (IsLeafType(returnType))
        {
            logger.LogDebug("Method {Method} returns leaf type {Type} — skipping", method.Name, returnType.Name);
            return null;
        }

        // Skip generic dictionaries (e.g., Dictionary<string, Dictionary<...>>)
        if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            return null;

        return returnType;
    }

    /// <summary>
    /// Gets a mapping of JSON property name → nested C# type (null for leaf/primitive types)
    /// for all [JsonPropertyName]-annotated properties on the given type.
    /// </summary>
    public Dictionary<string, Type?> GetJsonProperties(Type type)
    {
        var result = new Dictionary<string, Type?>(StringComparer.OrdinalIgnoreCase);

        foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            var jsonAttr = prop.GetCustomAttribute<JsonPropertyNameAttribute>();
            if (jsonAttr == null) continue;

            var propType = UnwrapType(prop.PropertyType);
            result[jsonAttr.Name] = IsLeafType(propType) ? null : propType;
        }

        return result;
    }

    /// <summary>
    /// Unwraps Nullable&lt;T&gt;, IEnumerable&lt;T&gt;, List&lt;T&gt;, etc. to get the element type.
    /// </summary>
    public static Type UnwrapType(Type type)
    {
        // Unwrap Nullable<T>
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            return UnwrapType(type.GetGenericArguments()[0]);

        // Unwrap collection types to their element type
        return UnwrapCollectionType(type);
    }

    private static Type UnwrapCollectionType(Type type)
    {
        if (!type.IsGenericType) return type;
        var def = type.GetGenericTypeDefinition();
        if (def == typeof(IEnumerable<>) || def == typeof(IReadOnlyList<>) ||
            def == typeof(IReadOnlyCollection<>) || def == typeof(List<>) ||
            def == typeof(IList<>) || def == typeof(ICollection<>))
            return type.GetGenericArguments()[0];
        return type;
    }

    private static bool IsLeafType(Type type)
    {
        if (type.IsPrimitive || type.IsEnum) return true;
        if (LeafTypes.Contains(type)) return true;
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>)) return true;
        return false;
    }
}
