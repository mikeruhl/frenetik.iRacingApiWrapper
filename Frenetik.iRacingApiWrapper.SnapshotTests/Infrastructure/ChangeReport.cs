namespace Frenetik.iRacingApiWrapper.SnapshotTests.Infrastructure;

public enum ChangeType
{
    NoChange,
    NewEndpoint,
    RemovedEndpoint,
    ModifiedResponse,
    NewError,
    ErrorResolved
}

public class PropertyChange
{
    public required string Path { get; init; }
    public required string ChangeDescription { get; init; }
    public object? OldValue { get; init; }
    public object? NewValue { get; init; }
}

public class EndpointChange
{
    public required string Method { get; init; }
    public required ChangeType ChangeType { get; init; }
    public List<PropertyChange> PropertyChanges { get; init; } = new();
    public string? ErrorMessage { get; init; }
}

public class ChangeReport
{
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
    public List<EndpointChange> Changes { get; init; } = new();
    public int TotalEndpointsChecked { get; set; }
    public int EndpointsWithChanges => Changes.Count;
    public bool HasChanges => Changes.Any();

    public string GenerateMarkdownReport()
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine("# iRacing API Snapshot Change Report");
        report.AppendLine();
        report.AppendLine($"**Report Generated:** {Timestamp:yyyy-MM-dd HH:mm:ss} UTC");
        report.AppendLine($"**Endpoints Checked:** {TotalEndpointsChecked}");
        report.AppendLine($"**Endpoints with Changes:** {EndpointsWithChanges}");
        report.AppendLine();

        if (!HasChanges)
        {
            report.AppendLine("✅ No changes detected. All API endpoints match previous snapshots.");
            return report.ToString();
        }

        report.AppendLine("## Summary");
        report.AppendLine();

        var changeTypeCounts = Changes.GroupBy(c => c.ChangeType)
            .Select(g => new { Type = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count);

        foreach (var typeCount in changeTypeCounts)
        {
            var emoji = typeCount.Type switch
            {
                ChangeType.NewEndpoint => "🆕",
                ChangeType.RemovedEndpoint => "❌",
                ChangeType.ModifiedResponse => "🔄",
                ChangeType.NewError => "⚠️",
                ChangeType.ErrorResolved => "✅",
                _ => "ℹ️"
            };
            report.AppendLine($"- {emoji} **{typeCount.Type}**: {typeCount.Count} endpoint(s)");
        }

        report.AppendLine();
        report.AppendLine("## Detailed Changes");
        report.AppendLine();

        foreach (var change in Changes.OrderBy(c => c.ChangeType).ThenBy(c => c.Method))
        {
            var emoji = change.ChangeType switch
            {
                ChangeType.NewEndpoint => "🆕",
                ChangeType.RemovedEndpoint => "❌",
                ChangeType.ModifiedResponse => "🔄",
                ChangeType.NewError => "⚠️",
                ChangeType.ErrorResolved => "✅",
                _ => "ℹ️"
            };

            report.AppendLine($"### {emoji} {change.Method}");
            report.AppendLine();
            report.AppendLine($"**Change Type:** {change.ChangeType}");

            if (!string.IsNullOrEmpty(change.ErrorMessage))
            {
                report.AppendLine();
                report.AppendLine($"**Error:** `{change.ErrorMessage}`");
            }

            if (change.PropertyChanges.Any())
            {
                report.AppendLine();
                report.AppendLine("**Property Changes:**");
                report.AppendLine();

                foreach (var propChange in change.PropertyChanges)
                {
                    report.AppendLine($"- **{propChange.Path}**");
                    report.AppendLine($"  - {propChange.ChangeDescription}");

                    if (propChange.OldValue != null || propChange.NewValue != null)
                    {
                        report.AppendLine($"  - Old: `{propChange.OldValue ?? "null"}`");
                        report.AppendLine($"  - New: `{propChange.NewValue ?? "null"}`");
                    }
                }
            }

            report.AppendLine();
        }

        return report.ToString();
    }
}
