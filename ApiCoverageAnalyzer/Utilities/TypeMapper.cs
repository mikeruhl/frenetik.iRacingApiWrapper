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
        var actualType = Nullable.GetUnderlyingType(dotnetType) ?? dotnetType;
        var typeName = actualType.Name;
        var apiTypeLower = apiType.ToLower();

        if (IsEnumCompatible(apiTypeLower, actualType))
            return true;

        if (IsGenericCompatible(apiTypeLower, actualType))
            return true;

        if (IsArrayCompatible(apiTypeLower, actualType))
            return true;

        return IsTypeMappingCompatible(apiTypeLower, typeName, actualType);
    }

    private static bool IsEnumCompatible(string apiTypeLower, Type actualType)
    {
        // Enums are compatible with string API types
        return actualType.IsEnum && (apiTypeLower == "string" || apiTypeLower == "str");
    }

    private static bool IsGenericCompatible(string apiTypeLower, Type actualType)
    {
        if (!actualType.IsGenericType)
            return false;

        var genericDef = actualType.GetGenericTypeDefinition();
        if (genericDef == typeof(IEnumerable<>) ||
            genericDef == typeof(List<>) ||
            genericDef == typeof(IList<>) ||
            genericDef == typeof(ICollection<>))
        {
            if (apiTypeLower == "numbers")
            {
                var elementType = actualType.GetGenericArguments()[0];
                return elementType == typeof(int) || elementType == typeof(Int32);
            }
            return apiTypeLower == "array" || apiTypeLower == "list";
        }
        return false;
    }

    private static bool IsArrayCompatible(string apiTypeLower, Type actualType)
    {
        if (!actualType.IsArray)
            return false;

        if (apiTypeLower == "numbers")
        {
            return actualType.GetElementType() == typeof(int);
        }
        return apiTypeLower == "array" || apiTypeLower == "list";
    }

    private static bool IsTypeMappingCompatible(string apiTypeLower, string typeName, Type actualType)
    {
        return (apiTypeLower, typeName) switch
        {
            ("number", "Int32" or "Int64" or "Int16" or "Byte" or "Single" or "Double" or "Decimal") => true,
            ("integer" or "int" or "int32", "Int32") => true,
            ("integer" or "int" or "int64" or "long", "Int64") => true,
            ("integer" or "int", "Int16") => true,
            ("integer" or "int", "Byte") => true,
            ("string" or "str", "String") => true,
            ("string" or "str", "DateTimeOffset") => true,
            ("boolean" or "bool", "Boolean") => true,
            ("float" or "single", "Single") => true,
            ("double" or "float", "Double") => true,
            ("decimal" or "float" or "double", "Decimal") => true,
            ("datetime" or "date" or "timestamp", "DateTimeOffset") => true,
            ("object" or "dictionary" or "dict", "Dictionary`2") => true,
            ("object", _) when !actualType.IsPrimitive => true,
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
