using System.Text.Json;

namespace Frenetik.iRacingApiWrapper.SnapshotTests.Infrastructure;

public class SnapshotManager
{
    private readonly string _snapshotDirectory;
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public SnapshotManager(string? snapshotDirectory = null)
    {
        _snapshotDirectory = snapshotDirectory ??
            Path.Combine(GetRepositoryRoot(), "snapshots");

        Directory.CreateDirectory(_snapshotDirectory);
    }

    public async Task SaveSnapshotAsync(Snapshot snapshot)
    {
        var fileName = GetSnapshotFileName(snapshot.Method);
        var filePath = Path.Combine(_snapshotDirectory, fileName);

        var json = JsonSerializer.Serialize(snapshot, SerializerOptions);
        await File.WriteAllTextAsync(filePath, json);
    }

    public async Task<Snapshot?> LoadSnapshotAsync(string methodName)
    {
        var fileName = GetSnapshotFileName(methodName);
        var filePath = Path.Combine(_snapshotDirectory, fileName);

        if (!File.Exists(filePath))
            return null;

        var json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<Snapshot>(json, SerializerOptions);
    }

    public async Task<Dictionary<string, Snapshot>> LoadAllSnapshotsAsync()
    {
        var snapshots = new Dictionary<string, Snapshot>();

        if (!Directory.Exists(_snapshotDirectory))
            return snapshots;

        foreach (var file in Directory.GetFiles(_snapshotDirectory, "*.json"))
        {
            var json = await File.ReadAllTextAsync(file);
            var snapshot = JsonSerializer.Deserialize<Snapshot>(json, SerializerOptions);

            if (snapshot != null)
            {
                snapshots[snapshot.Method] = snapshot;
            }
        }

        return snapshots;
    }

    private static string GetSnapshotFileName(string methodName)
    {
        return $"{methodName}.snapshot.json";
    }

    private static string GetRepositoryRoot()
    {
        var currentDir = Directory.GetCurrentDirectory();

        while (!string.IsNullOrEmpty(currentDir))
        {
            if (Directory.Exists(Path.Combine(currentDir, ".git")))
                return currentDir;

            currentDir = Directory.GetParent(currentDir)?.FullName;
        }

        throw new InvalidOperationException("Could not find repository root (no .git directory found)");
    }
}
