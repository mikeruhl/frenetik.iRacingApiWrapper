namespace ApiCoverageAnalyzer.Utilities;

/// <summary>
/// Provides path normalization utilities for consistent API path handling
/// </summary>
public static class PathNormalizer
{
    private const string DataPrefix = "/data/";
    private const string DataPrefixNoSlash = "data/";
    private const int DataPrefixLength = 6; // "/data/".Length
    private const int DataPrefixNoSlashLength = 5; // "data/".Length

    /// <summary>
    /// Normalizes an API path by removing leading slashes and data prefixes
    /// </summary>
    /// <param name="path">The path to normalize</param>
    /// <returns>The normalized path</returns>
    public static string Normalize(string path)
    {
        if (string.IsNullOrEmpty(path))
            return string.Empty;

        // Remove leading slash
        var normalized = path.TrimStart('/');

        // Remove data/ prefix if present
        if (normalized.StartsWith(DataPrefixNoSlash, StringComparison.OrdinalIgnoreCase))
        {
            normalized = normalized.Substring(DataPrefixNoSlashLength);
        }

        return normalized;
    }

    /// <summary>
    /// Generates all possible path variations for flexible matching
    /// </summary>
    /// <param name="path">The original path</param>
    /// <returns>A collection of path variations</returns>
    public static IEnumerable<string> GetPathVariations(string path)
    {
        if (string.IsNullOrEmpty(path))
            yield break;

        // 1. Original path
        yield return path;

        // 2. With leading slash (if it doesn't have one)
        if (!path.StartsWith('/'))
        {
            yield return "/" + path;
        }

        // 3. Without leading slash (if it has one)
        var normalizedPath = path.TrimStart('/');
        if (normalizedPath != path)
        {
            yield return normalizedPath;
        }

        // 4. Without /data/ prefix if present
        if (path.StartsWith(DataPrefix, StringComparison.OrdinalIgnoreCase))
        {
            var withoutData = path.Substring(DataPrefixLength);
            yield return withoutData;
        }
        else if (path.StartsWith(DataPrefixNoSlash, StringComparison.OrdinalIgnoreCase))
        {
            var withoutData = path.Substring(DataPrefixNoSlashLength);
            yield return withoutData;
        }

        // 5. Normalized form (without leading slash and without data prefix)
        var fullyNormalized = Normalize(path);
        if (fullyNormalized != path && !string.IsNullOrEmpty(fullyNormalized))
        {
            yield return fullyNormalized;
        }
    }

    /// <summary>
    /// Extracts the path component from a full URL
    /// </summary>
    /// <param name="url">The URL to extract from</param>
    /// <returns>The extracted path without the /data prefix</returns>
    public static string ExtractPathFromUrl(string url)
    {
        if (string.IsNullOrEmpty(url))
            return string.Empty;

        try
        {
            var uri = new Uri(url);
            var path = uri.AbsolutePath;

            // Remove /data prefix if present
            if (path.StartsWith(DataPrefix, StringComparison.OrdinalIgnoreCase))
            {
                return path.Substring(DataPrefixLength);
            }

            return path;
        }
        catch (UriFormatException)
        {
            // If URL parsing fails, try to extract path manually
            return Normalize(url);
        }
    }

    /// <summary>
    /// Checks if two paths are equivalent after normalization
    /// </summary>
    /// <param name="path1">First path</param>
    /// <param name="path2">Second path</param>
    /// <param name="comparisonType">String comparison type</param>
    /// <returns>True if paths are equivalent</returns>
    public static bool AreEquivalent(string path1, string path2, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
    {
        if (string.IsNullOrEmpty(path1) && string.IsNullOrEmpty(path2))
            return true;

        if (string.IsNullOrEmpty(path1) || string.IsNullOrEmpty(path2))
            return false;

        var normalized1 = Normalize(path1);
        var normalized2 = Normalize(path2);

        return normalized1.Equals(normalized2, comparisonType);
    }
}
