using System.Reflection;
using System.Reflection.Emit;

namespace ApiCoverageAnalyzer.Discovery;

/// <summary>
/// Extracts the API path from wrapper methods by inspecting IL code
/// </summary>
public static class MethodPathExtractor
{
    /// <summary>
    /// Extract the path parameter passed to GetResources from a method's IL code
    /// </summary>
    public static string? ExtractPath(MethodInfo method)
    {
        try
        {
            // First try extracting from the method itself
            var path = ExtractPathFromIL(method);
            if (path != null)
                return path;

            // If the method is async, the real implementation is in the state machine
            // Look for the AsyncStateMachineAttribute
            var asyncAttr = method.GetCustomAttribute<System.Runtime.CompilerServices.AsyncStateMachineAttribute>();
            if (asyncAttr != null)
            {
                // Get the state machine type
                var stateMachineType = asyncAttr.StateMachineType;

                // Find the MoveNext method which contains the actual implementation
                var moveNextMethod = stateMachineType.GetMethod("MoveNext", BindingFlags.NonPublic | BindingFlags.Instance);
                if (moveNextMethod != null)
                {
                    path = ExtractPathFromIL(moveNextMethod);
                    if (path != null)
                        return path;
                }
            }

            return null;
        }
        catch
        {
            // If IL inspection fails, return null
            return null;
        }
    }

    private static string? ExtractPathFromIL(MethodInfo method)
    {
        try
        {
            var methodBody = method.GetMethodBody();
            if (methodBody == null)
                return null;

            var il = methodBody.GetILAsByteArray();
            if (il == null)
                return null;

            // Parse IL to find string literals (ldstr instruction)
            // ldstr opcode is 0x72
            var strings = new List<string>();

            for (int i = 0; i < il.Length; i++)
            {
                // Check for ldstr opcode (0x72)
                if (il[i] == 0x72)
                {
                    // Next 4 bytes are the metadata token for the string
                    if (i + 4 < il.Length)
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
                        catch
                        {
                            // Token resolution failed, continue
                        }

                        i += 4; // Skip the token bytes
                    }
                }
            }

            // Find the first string that looks like a path (starts with /)
            var path = strings.FirstOrDefault(s => s.StartsWith("/"));

            return path;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Extract paths from all methods and create a mapping
    /// </summary>
    public static Dictionary<string, MethodInfo> ExtractPathsFromMethods(IEnumerable<MethodInfo> methods)
    {
        var pathToMethod = new Dictionary<string, MethodInfo>(StringComparer.OrdinalIgnoreCase);

        foreach (var method in methods)
        {
            var path = ExtractPath(method);
            if (!string.IsNullOrEmpty(path))
            {
                // Normalize path (remove /data prefix if present for matching)
                var normalizedPath = path.TrimStart('/');

                // Store both the original path and without /data prefix
                pathToMethod[path] = method;
                pathToMethod[normalizedPath] = method;

                // Also store without leading /data/
                if (path.StartsWith("/data/"))
                {
                    var withoutData = path.Substring(6); // Remove "/data/"
                    pathToMethod[withoutData] = method;
                }
            }
        }

        return pathToMethod;
    }
}
