using System.Text.Json;

namespace Frenetik.iRacingApiWrapper.SnapshotTests.Infrastructure;

public class SnapshotComparer
{
    public ChangeReport CompareSnapshots(
        Dictionary<string, Snapshot> oldSnapshots,
        Dictionary<string, Snapshot> newSnapshots)
    {
        var report = new ChangeReport
        {
            TotalEndpointsChecked = newSnapshots.Count
        };

        var allMethods = oldSnapshots.Keys.Union(newSnapshots.Keys).ToHashSet();

        foreach (var method in allMethods)
        {
            var hasOld = oldSnapshots.TryGetValue(method, out var oldSnapshot);
            var hasNew = newSnapshots.TryGetValue(method, out var newSnapshot);

            if (!hasOld && hasNew)
            {
                report.Changes.Add(new EndpointChange
                {
                    Method = method,
                    ChangeType = ChangeType.NewEndpoint
                });
            }
            else if (hasOld && !hasNew)
            {
                report.Changes.Add(new EndpointChange
                {
                    Method = method,
                    ChangeType = ChangeType.RemovedEndpoint
                });
            }
            else if (hasOld && hasNew)
            {
                var change = CompareEndpoint(oldSnapshot!, newSnapshot!);
                if (change != null)
                {
                    report.Changes.Add(change);
                }
            }
        }

        return report;
    }

    private EndpointChange? CompareEndpoint(Snapshot oldSnapshot, Snapshot newSnapshot)
    {
        if (oldSnapshot.Success && !newSnapshot.Success)
        {
            return new EndpointChange
            {
                Method = newSnapshot.Method,
                ChangeType = ChangeType.NewError,
                ErrorMessage = newSnapshot.ErrorMessage
            };
        }

        if (!oldSnapshot.Success && newSnapshot.Success)
        {
            return new EndpointChange
            {
                Method = newSnapshot.Method,
                ChangeType = ChangeType.ErrorResolved
            };
        }

        if (!oldSnapshot.Success && !newSnapshot.Success)
        {
            return null;
        }

        var propertyChanges = CompareJsonResponses(
            oldSnapshot.ResponseJson,
            newSnapshot.ResponseJson);

        if (propertyChanges.Any())
        {
            return new EndpointChange
            {
                Method = newSnapshot.Method,
                ChangeType = ChangeType.ModifiedResponse,
                PropertyChanges = propertyChanges
            };
        }

        return null;
    }

    private List<PropertyChange> CompareJsonResponses(string? oldJson, string? newJson)
    {
        var changes = new List<PropertyChange>();

        if (string.IsNullOrEmpty(oldJson) || string.IsNullOrEmpty(newJson))
        {
            if (oldJson != newJson)
            {
                changes.Add(new PropertyChange
                {
                    Path = "$",
                    ChangeDescription = "Response changed from empty to non-empty or vice versa",
                    OldValue = oldJson,
                    NewValue = newJson
                });
            }
            return changes;
        }

        try
        {
            using var oldDoc = JsonDocument.Parse(oldJson);
            using var newDoc = JsonDocument.Parse(newJson);

            CompareJsonElements(oldDoc.RootElement, newDoc.RootElement, "$", changes);
        }
        catch (JsonException ex)
        {
            changes.Add(new PropertyChange
            {
                Path = "$",
                ChangeDescription = $"JSON parsing error: {ex.Message}",
                OldValue = oldJson?.Length > 100 ? oldJson[..100] + "..." : oldJson,
                NewValue = newJson?.Length > 100 ? newJson[..100] + "..." : newJson
            });
        }

        return changes;
    }

    private void CompareJsonElements(
        JsonElement oldElement,
        JsonElement newElement,
        string path,
        List<PropertyChange> changes)
    {
        if (oldElement.ValueKind != newElement.ValueKind)
        {
            changes.Add(new PropertyChange
            {
                Path = path,
                ChangeDescription = $"Type changed from {oldElement.ValueKind} to {newElement.ValueKind}",
                OldValue = GetValueString(oldElement),
                NewValue = GetValueString(newElement)
            });
            return;
        }

        switch (oldElement.ValueKind)
        {
            case JsonValueKind.Object:
                CompareObjects(oldElement, newElement, path, changes);
                break;

            case JsonValueKind.Array:
                CompareArrays(oldElement, newElement, path, changes);
                break;

            case JsonValueKind.String:
            case JsonValueKind.Number:
            case JsonValueKind.True:
            case JsonValueKind.False:
            case JsonValueKind.Null:
                if (GetValueString(oldElement) != GetValueString(newElement))
                {
                    changes.Add(new PropertyChange
                    {
                        Path = path,
                        ChangeDescription = "Value changed",
                        OldValue = GetValueString(oldElement),
                        NewValue = GetValueString(newElement)
                    });
                }
                break;
        }
    }

    private void CompareObjects(
        JsonElement oldObj,
        JsonElement newObj,
        string path,
        List<PropertyChange> changes)
    {
        var oldProps = oldObj.EnumerateObject().Select(p => p.Name).ToHashSet();
        var newProps = newObj.EnumerateObject().Select(p => p.Name).ToHashSet();

        var addedProps = newProps.Except(oldProps).ToList();
        var removedProps = oldProps.Except(newProps).ToList();
        var commonProps = oldProps.Intersect(newProps).ToList();

        foreach (var prop in addedProps)
        {
            changes.Add(new PropertyChange
            {
                Path = $"{path}.{prop}",
                ChangeDescription = "New property added",
                NewValue = GetValueString(newObj.GetProperty(prop))
            });
        }

        foreach (var prop in removedProps)
        {
            changes.Add(new PropertyChange
            {
                Path = $"{path}.{prop}",
                ChangeDescription = "Property removed",
                OldValue = GetValueString(oldObj.GetProperty(prop))
            });
        }

        foreach (var prop in commonProps)
        {
            CompareJsonElements(
                oldObj.GetProperty(prop),
                newObj.GetProperty(prop),
                $"{path}.{prop}",
                changes);
        }
    }

    private void CompareArrays(
        JsonElement oldArray,
        JsonElement newArray,
        string path,
        List<PropertyChange> changes)
    {
        var oldLength = oldArray.GetArrayLength();
        var newLength = newArray.GetArrayLength();

        if (oldLength != newLength)
        {
            changes.Add(new PropertyChange
            {
                Path = path,
                ChangeDescription = "Array length changed",
                OldValue = oldLength,
                NewValue = newLength
            });
        }

        if (oldLength == 0 || newLength == 0)
            return;

        CompareJsonElements(
            oldArray[0],
            newArray[0],
            $"{path}[0]",
            changes);
    }

    private static string GetValueString(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.String => element.GetString() ?? "",
            JsonValueKind.Number => element.GetRawText(),
            JsonValueKind.True => "true",
            JsonValueKind.False => "false",
            JsonValueKind.Null => "null",
            _ => element.GetRawText()
        };
    }
}
