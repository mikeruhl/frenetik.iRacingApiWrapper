namespace ApiCoverageAnalyzer.Utilities;

/// <summary>
/// Handles naming convention conversions between snake_case and camelCase/PascalCase
/// </summary>
public class NamingConventions
{
    /// <summary>
    /// Convert snake_case to camelCase
    /// </summary>
    public string ToCamelCase(string snakeCase)
    {
        if (string.IsNullOrWhiteSpace(snakeCase))
            return snakeCase;

        var parts = snakeCase.Split('_');
        if (parts.Length == 1)
            return parts[0];

        // First part stays lowercase, rest are Title Case
        return parts[0] + string.Concat(parts.Skip(1).Select(TitleCase));
    }

    /// <summary>
    /// Convert snake_case to PascalCase
    /// </summary>
    public string ToPascalCase(string snakeCase)
    {
        if (string.IsNullOrWhiteSpace(snakeCase))
            return snakeCase;

        var parts = snakeCase.Split('_');
        return string.Concat(parts.Select(TitleCase));
    }

    /// <summary>
    /// Convert camelCase or PascalCase to snake_case
    /// </summary>
    public string ToSnakeCase(string camelCase)
    {
        if (string.IsNullOrWhiteSpace(camelCase))
            return camelCase;

        var result = new System.Text.StringBuilder();
        result.Append(char.ToLower(camelCase[0]));

        for (int i = 1; i < camelCase.Length; i++)
        {
            if (char.IsUpper(camelCase[i]))
            {
                result.Append('_');
                result.Append(char.ToLower(camelCase[i]));
            }
            else
            {
                result.Append(camelCase[i]);
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// Convert endpoint path to expected method name
    /// Examples:
    /// - /member/info -> GetMemberInfo
    /// - /data/car/get -> GetCar
    /// - /data/results/search_series -> GetResultsSearchSeries
    /// </summary>
    public string EndpointToMethodName(string endpointKey, string endpointLink)
    {
        // Use the link (actual path) for conversion
        var path = endpointLink.TrimStart('/');

        // Remove /data/ prefix if present
        if (path.StartsWith("data/"))
        {
            path = path.Substring(5);
        }

        // Split by / and convert each part
        var parts = path.Split('/');
        var methodParts = new List<string> { "Get" };

        foreach (var part in parts)
        {
            if (string.IsNullOrWhiteSpace(part) || part == "get")
                continue;

            // Convert snake_case parts to PascalCase
            if (part.Contains('_'))
            {
                methodParts.Add(ToPascalCase(part));
            }
            else
            {
                methodParts.Add(TitleCase(part));
            }
        }

        return string.Concat(methodParts);
    }

    private string TitleCase(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return s;

        return char.ToUpper(s[0]) + s.Substring(1).ToLower();
    }
}
