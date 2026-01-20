using System.Reflection;

namespace ApiCoverageAnalyzer.Utilities;

/// <summary>
/// Maps API type strings to .NET types
/// </summary>
public class TypeMapper
{
    /// <summary>
    /// Check if API type is compatible with .NET type
    /// </summary>
    public bool AreCompatible(string apiType, Type dotnetType)
    {
        // Unwrap nullable types
        var actualType = Nullable.GetUnderlyingType(dotnetType) ?? dotnetType;
        var typeName = actualType.Name;

        // Handle generic types (IEnumerable<T>, List<T>, etc.)
        if (actualType.IsGenericType)
        {
            var genericDef = actualType.GetGenericTypeDefinition();
            if (genericDef == typeof(IEnumerable<>) ||
                genericDef == typeof(List<>) ||
                genericDef == typeof(IList<>) ||
                genericDef == typeof(ICollection<>))
            {
                // Arrays/collections are compatible with "array" or the element type
                return apiType == "array" || apiType == "list";
            }
        }

        // Handle array types
        if (actualType.IsArray)
        {
            return apiType == "array" || apiType == "list";
        }

        // Type compatibility mappings
        return (apiType.ToLower(), typeName) switch
        {
            // Number type (generic numeric from API - matches any numeric type)
            ("number", "Int32" or "Int64" or "Int16" or "Byte" or "Single" or "Double" or "Decimal") => true,

            // Integer types
            ("integer" or "int" or "int32", "Int32") => true,
            ("integer" or "int" or "int64" or "long", "Int64") => true,
            ("integer" or "int", "Int16") => true,
            ("integer" or "int", "Byte") => true,

            // String types
            ("string" or "str", "String") => true,

            // Boolean types
            ("boolean" or "bool", "Boolean") => true,

            // Floating point types
            ("float" or "single", "Single") => true,
            ("double" or "float", "Double") => true,
            ("decimal" or "float" or "double", "Decimal") => true,

            // Date/Time types
            ("datetime" or "date" or "timestamp", "DateTime") => true,
            ("datetime" or "date" or "timestamp", "DateTimeOffset") => true,

            // Object/dictionary types
            ("object" or "dictionary" or "dict", "Dictionary`2") => true,
            ("object", _) when !actualType.IsPrimitive => true,

            // Default: not compatible
            _ => false
        };
    }

    /// <summary>
    /// Get the .NET type name for an API type
    /// </summary>
    public string GetDotNetTypeName(string apiType)
    {
        return apiType.ToLower() switch
        {
            "integer" or "int" => "int",
            "string" or "str" => "string",
            "boolean" or "bool" => "bool",
            "float" => "float",
            "double" => "double",
            "datetime" or "date" => "DateTime",
            "array" or "list" => "List<>",
            "object" or "dictionary" => "object",
            _ => "object"
        };
    }
}
