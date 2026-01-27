using System.Reflection;
using System.Reflection.Emit;
using ApiCoverageAnalyzer.Utilities;
using Microsoft.Extensions.Logging;

namespace ApiCoverageAnalyzer.Discovery;

/// <summary>
/// Extracts the API path from wrapper methods by inspecting IL code
/// </summary>
public class MethodPathExtractor(ILogger<MethodPathExtractor> logger)
{
    private const byte LdstrOpcode = 0x72;
    private const int MetadataTokenSize = 4;
    private const int MaxPathSegmentLength = 50;
    private const int MinPathSegments = 2;
    private const int MaxPathSegments = 5;

    /// <summary>
    /// Extract the path parameter passed to GetResources from a method's IL code
    /// </summary>
    public string? ExtractPath(MethodInfo method)
    {
        try
        {
            // First try extracting from the method itself
            var path = ExtractPathFromIL(method);
            if (path is not null)
                return path;

            // If the method is async, the real implementation is in the state machine
            // Look for the AsyncStateMachineAttribute
            var asyncAttr = method.GetCustomAttribute<System.Runtime.CompilerServices.AsyncStateMachineAttribute>();
            if (asyncAttr is not null)
            {
                // Get the state machine type
                var stateMachineType = asyncAttr.StateMachineType;

                // Find the MoveNext method which contains the actual implementation
                var moveNextMethod = stateMachineType.GetMethod("MoveNext", BindingFlags.NonPublic | BindingFlags.Instance);
                if (moveNextMethod is not null)
                {
                    path = ExtractPathFromIL(moveNextMethod);
                    if (path is not null)
                        return path;
                }
            }

            return null;
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning(ex, "Invalid operation while extracting path from method {MethodName}", method.Name);
            return null;
        }
        catch (NotSupportedException ex)
        {
            logger.LogWarning(ex, "Unsupported IL operation while extracting path from method {MethodName}", method.Name);
            return null;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error extracting path from method {MethodName}", method.Name);
            return null;
        }
    }

    private string? ExtractPathFromIL(MethodInfo method)
    {
        try
        {
            var methodBody = method.GetMethodBody();
            if (methodBody is null)
            {
                logger.LogDebug("Method {MethodName} has no body", method.Name);
                return null;
            }

            var il = methodBody.GetILAsByteArray();
            if (il is null)
            {
                logger.LogDebug("Method {MethodName} has no IL bytes", method.Name);
                return null;
            }

            // Parse IL to find string literals (ldstr instruction)
            var strings = new List<string>();

            for (int i = 0; i < il.Length; i++)
            {
                // Check for ldstr opcode
                if (il[i] == LdstrOpcode)
                {
                    // Next bytes are the metadata token for the string
                    if (i + MetadataTokenSize < il.Length)
                    {
                        int token = BitConverter.ToInt32(il, i + 1);

                        // Resolve the string from the metadata token
                        try
                        {
                            var str = method.Module.ResolveString(token);
                            if (!string.IsNullOrEmpty(str))
                            {
                                strings.Add(str);
                            }
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            logger.LogDebug(ex, "Invalid metadata token 0x{Token:X8} in method {MethodName}", token, method.Name);
                        }
                        catch (ArgumentException ex)
                        {
                            logger.LogDebug(ex, "Token 0x{Token:X8} does not reference a string in method {MethodName}", token, method.Name);
                        }

                        i += MetadataTokenSize; // Skip the token bytes
                    }
                }
            }

            // Find the first string that looks like an API path
            var path = strings.FirstOrDefault(IsApiPath);

            if (path is not null)
            {
                logger.LogDebug("Extracted path '{Path}' from method {MethodName}", path, method.Name);
            }

            return path;
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning(ex, "Invalid operation while parsing IL for method {MethodName}", method.Name);
            return null;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error parsing IL for method {MethodName}", method.Name);
            return null;
        }
    }

    /// <summary>
    /// Check if a string looks like an API path
    /// </summary>
    private static bool IsApiPath(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return false;

        // Starts with "/" is definitely a path
        if (str.StartsWith("/"))
            return true;

        // Check if it matches common API path patterns without leading slash
        // e.g., "member/info", "data/car/get", "season/race_guide"
        // Must contain at least one "/" and use lowercase with underscores
        if (str.Contains("/") &&
            str.All(c => char.IsLower(c) || c == '/' || c == '_' || char.IsDigit(c)))
        {
            // Additional check: shouldn't be too long (avoid matching file paths or other strings)
            // and should have reasonable path segments
            var parts = str.Split('/');
            if (parts.Length >= MinPathSegments &&
                parts.Length <= MaxPathSegments &&
                parts.All(p => p.Length > 0 && p.Length < MaxPathSegmentLength))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Extract paths from all methods and create a mapping
    /// </summary>
    public Dictionary<string, MethodInfo> ExtractPathsFromMethods(IEnumerable<MethodInfo> methods)
    {
        var pathToMethod = new Dictionary<string, MethodInfo>(StringComparer.OrdinalIgnoreCase);
        var methodCount = 0;
        var pathsExtracted = 0;

        foreach (var method in methods)
        {
            methodCount++;
            var path = ExtractPath(method);
            if (!string.IsNullOrEmpty(path))
            {
                pathsExtracted++;
                // Store multiple variations of the path for flexible matching
                foreach (var variation in PathNormalizer.GetPathVariations(path))
                {
                    pathToMethod[variation] = method;
                }
            }
        }

        logger.LogInformation("Extracted paths from {PathsExtracted}/{MethodCount} methods, created {VariationCount} path variations",
            pathsExtracted, methodCount, pathToMethod.Count);

        return pathToMethod;
    }
}
