using Frenetik.iRacingApiWrapper.Config;
using Frenetik.iRacingApiWrapper.SnapshotTests.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text.Json;

namespace Frenetik.iRacingApiWrapper.SnapshotTests;

public class ApiSnapshotTests
{
    private readonly SnapshotManager _snapshotManager;
    private readonly SnapshotComparer _comparer;

    public ApiSnapshotTests()
    {
        _snapshotManager = new SnapshotManager();
        _comparer = new SnapshotComparer();
    }

    [Fact]
    public async Task CaptureApiSnapshots()
    {
        var service = CreateApiService();
        var snapshots = await CaptureAllEndpointsAsync(service);

        Assert.NotEmpty(snapshots);

        foreach (var snapshot in snapshots.Values)
        {
            await _snapshotManager.SaveSnapshotAsync(snapshot);
        }
    }

    [Fact]
    public async Task CompareApiSnapshots()
    {
        var oldSnapshots = await _snapshotManager.LoadAllSnapshotsAsync();

        if (!oldSnapshots.Any())
        {
            throw new InvalidOperationException(
                "No existing snapshots found. Run CaptureApiSnapshots first to create baseline snapshots.");
        }

        var service = CreateApiService();
        var newSnapshots = await CaptureAllEndpointsAsync(service);

        var report = _comparer.CompareSnapshots(oldSnapshots, newSnapshots);

        var reportPath = Path.Combine(
            _snapshotManager.GetType().GetField("_snapshotDirectory",
                BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(_snapshotManager) as string ?? "snapshots",
            $"change-report-{DateTime.UtcNow:yyyy-MM-dd-HHmmss}.md");

        await File.WriteAllTextAsync(reportPath, report.GenerateMarkdownReport());

        Assert.False(report.HasChanges,
            $"API changes detected! {report.EndpointsWithChanges} endpoint(s) changed. See {reportPath} for details.");
    }

    private async Task<Dictionary<string, Snapshot>> CaptureAllEndpointsAsync(IRacingApiService service)
    {
        var snapshots = new Dictionary<string, Snapshot>();
        var methods = GetApiMethods();

        foreach (var method in methods)
        {
            var snapshot = await CaptureEndpointAsync(service, method);
            snapshots[method.Name] = snapshot;
        }

        return snapshots;
    }

    private async Task<Snapshot> CaptureEndpointAsync(IRacingApiService service, MethodInfo method)
    {
        var snapshot = new Snapshot
        {
            Endpoint = $"/data/{method.Name}",
            Method = method.Name,
            Timestamp = DateTime.UtcNow,
            Success = false
        };

        try
        {
            var parameters = method.GetParameters();
            object?[]? args = null;

            if (parameters.Length > 0)
            {
                args = new object?[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    args[i] = GetDefaultParameterValue(parameters[i]);
                }
            }

            var task = method.Invoke(service, args) as Task;
            if (task == null)
            {
                snapshot.ErrorMessage = "Method did not return a Task";
                return snapshot;
            }

            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result");
            var result = resultProperty?.GetValue(task);

            if (result != null)
            {
                var json = JsonSerializer.Serialize(result, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                snapshot.Success = true;
                snapshot.ResponseJson = json;
                snapshot.StatusCode = 200;
            }
            else
            {
                snapshot.Success = true;
                snapshot.ResponseJson = "null";
                snapshot.StatusCode = 200;
            }
        }
        catch (TargetInvocationException ex) when (ex.InnerException != null)
        {
            snapshot.ErrorMessage = ex.InnerException.Message;
            snapshot.StatusCode = 500;
        }
        catch (Exception ex)
        {
            snapshot.ErrorMessage = ex.Message;
            snapshot.StatusCode = 500;
        }

        return snapshot;
    }

    private static object? GetDefaultParameterValue(ParameterInfo parameter)
    {
        if (parameter.HasDefaultValue)
            return parameter.DefaultValue;

        var type = parameter.ParameterType;

        if (type == typeof(string))
            return null;

        if (type == typeof(int) || type == typeof(int?))
            return 0;

        if (type == typeof(bool) || type == typeof(bool?))
            return false;

        if (type == typeof(DateTime) || type == typeof(DateTime?))
            return DateTime.UtcNow.AddDays(-7);

        if (type.IsEnum)
            return Enum.GetValues(type).GetValue(0);

        return null;
    }

    private static List<MethodInfo> GetApiMethods()
    {
        var serviceType = typeof(IRacingApiService);

        return serviceType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m.DeclaringType == serviceType)
            .Where(m => m.ReturnType.IsGenericType &&
                        m.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
            .Where(m => !m.Name.StartsWith("get_"))
            .OrderBy(m => m.Name)
            .ToList();
    }

    private static IRacingApiService CreateApiService()
    {
        var username = Environment.GetEnvironmentVariable("IRACING_USERNAME")
            ?? throw new InvalidOperationException("IRACING_USERNAME environment variable not set");

        var password = Environment.GetEnvironmentVariable("IRACING_PASSWORD")
            ?? throw new InvalidOperationException("IRACING_PASSWORD environment variable not set");

        var settings = Options.Create(new IRacingDataSettings
        {
            BaseUrl = "https://members-ng.iracing.com/",
            Username = username,
            Password = password
        });

        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Warning);
        });

        var logger = loggerFactory.CreateLogger<IRacingApiService>();

        return new IRacingApiService(settings, logger);
    }
}
