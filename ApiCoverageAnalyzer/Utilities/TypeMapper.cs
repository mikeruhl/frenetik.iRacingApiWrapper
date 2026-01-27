using System.Reflection;

namespace ApiCoverageAnalyzer.Utilities;

/// <summary>
/// Maps API type strings to .NET types
/// </summary>
public static class TypeMapper
{
    /// <summary>
    /// Check if API type is compatible with .NET type
    /// </summary>
    public static bool AreCompatible(string apiType, Type dotnetType)
    {
        // Unwrap nullable types
        var actualType = Nullable.GetUnderlyingType(dotnetType) ?? dotnetType;
        var typeName = actualType.Name;

        // Handle enum types - enums are compatible with string API types
        if (actualType.IsEnum)
        {
            return apiType.ToLower() is "string" or "str";
        }

        // Handle generic types (IEnumerable<T>, List<T>, etc.)
        if (actualType.IsGenericType)
        {
            var genericDef = actualType.GetGenericTypeDefinition();
            if (genericDef == typeof(IEnumerable<>) ||
                genericDef == typeof(List<>) ||
                genericDef == typeof(IList<>) ||
                genericDef == typeof(ICollection<>))
            {
                // Check for "numbers" type - should be IEnumerable<int> or similar int collection
                if (apiType.ToLower() == "numbers")
                {
                    var elementType = actualType.GetGenericArguments()[0];
                    return elementType == typeof(int) || elementType == typeof(Int32);
                }

                // Arrays/collections are compatible with "array" or the element type
                return apiType == "array" || apiType == "list";
            }
        }

        // Handle array types
        if (actualType.IsArray)
        {
            // Check for "numbers" type - should be int[]
            if (apiType.ToLower() == "numbers")
            {
                return actualType.GetElementType() == typeof(int);
            }

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
            // DateTimeOffset is compatible with string (dates are sent as ISO-8601 strings)
            ("string" or "str", "DateTimeOffset") => true,

            // Boolean types
            ("boolean" or "bool", "Boolean") => true,

            // Floating point types
            ("float" or "single", "Single") => true,
            ("double" or "float", "Double") => true,
            ("decimal" or "float" or "double", "Decimal") => true,

            // Date/Time types - enforce DateTimeOffset for ISO-8601 dates
            ("datetime" or "date" or "timestamp", "DateTimeOffset") => true,

            // Object/dictionary types
            ("object" or "dictionary" or "dict", "Dictionary`2") => true,
            ("object", _) when !actualType.IsPrimitive => true,

            // Default: not compatible
            _ => false
        };
    }

    /// <summary>
    /// Check if the nullable state of a .NET type matches the required state of an API parameter
    /// </summary>
    /// <param name="dotnetType">The .NET parameter type</param>
    /// <param name="isRequired">Whether the API parameter is required</param>
    /// <returns>True if nullable state matches requirement, false otherwise</returns>
    public static bool IsNullableStateCorrect(Type dotnetType, bool isRequired)
    {
        var isNullable = Nullable.GetUnderlyingType(dotnetType) is not null || !dotnetType.IsValueType;

        if (isRequired)
        {
            if (dotnetType.IsValueType)
            {
                return !isNullable;
            }
            return true;
        }
        else
        {
            return isNullable;
        }
    }

    /// <summary>
    /// Get the .NET type name for an API type
    /// </summary>
    public static string GetDotNetTypeName(string apiType)
    {
        return apiType.ToLower() switch
        {
            "integer" or "int" => "int",
            "string" or "str" => "string",
            "boolean" or "bool" => "bool",
            "float" => "float",
            "double" => "double",
            "datetime" or "date" => "DateTimeOffset",
            "numbers" => "IEnumerable<int>",
            "array" or "list" => "List<>",
            "object" or "dictionary" => "object",
            _ => "object"
        };
    }
}
