# iRacing API Snapshot Testing

This project provides automated snapshot testing for the iRacing API wrapper to detect and track API changes over time.

## Overview

The snapshot testing system:
- **Captures** responses from all API endpoints
- **Compares** new responses with previously saved snapshots
- **Detects** changes in API structure, new properties, removed fields, and modified values
- **Reports** changes in a human-readable markdown format
- **Automates** monitoring via GitHub Actions with scheduled runs
- **Notifies** maintainers via GitHub Issues when changes are detected

## Quick Start

### Prerequisites

Set environment variables with your iRacing credentials:

```bash
export IRACING_USERNAME="your_username"
export IRACING_PASSWORD="your_password"
```

**Note:** iRacing requires Legacy Authentication to be enabled in your account settings at https://oauth.iracing.com/accountmanagement/security/

### Capture Initial Snapshots

To create baseline snapshots of all API endpoints:

```bash
dotnet test --filter "FullyQualifiedName=Frenetik.iRacingApiWrapper.SnapshotTests.ApiSnapshotTests.CaptureApiSnapshots"
```

This will:
- Call all 70+ API methods
- Capture their responses
- Save snapshots as JSON files in the `snapshots/` directory
- Commit these files to git for version tracking

### Compare Snapshots

To check for API changes:

```bash
dotnet test --filter "FullyQualifiedName=Frenetik.iRacingApiWrapper.SnapshotTests.ApiSnapshotTests.CompareApiSnapshots"
```

This will:
- Execute all API methods again
- Compare new responses with saved snapshots
- Generate a change report if differences are detected
- Fail the test if changes are found

## Architecture

### Core Components

**Snapshot** (`Infrastructure/Snapshot.cs`)
- Data model representing a captured API response
- Includes endpoint, method name, timestamp, success status, and response JSON

**SnapshotManager** (`Infrastructure/SnapshotManager.cs`)
- Handles loading and saving snapshot files
- Manages the `snapshots/` directory
- Uses JSON serialization with pretty-printing for readability

**SnapshotComparer** (`Infrastructure/SnapshotComparer.cs`)
- Performs deep comparison of JSON responses
- Detects new/removed properties
- Identifies value changes
- Handles type changes and array modifications

**ChangeReport** (`Infrastructure/ChangeReport.cs`)
- Represents detected changes
- Categorizes changes by type (new endpoint, modified response, errors, etc.)
- Generates formatted markdown reports

**ApiSnapshotTests** (`ApiSnapshotTests.cs`)
- Main test class
- Uses reflection to discover all API methods
- Invokes methods with default parameters
- Orchestrates snapshot capture and comparison

### Change Detection

The comparer detects:
- ✅ **New Endpoints**: API methods not in previous snapshots
- ❌ **Removed Endpoints**: Previously tracked methods no longer available
- 🔄 **Modified Responses**: Changes to JSON structure or values
  - New properties added
  - Properties removed
  - Value changes
  - Type changes
  - Array length modifications
- ⚠️ **New Errors**: Endpoints that started failing
- ✅ **Errors Resolved**: Previously failing endpoints now working

## GitHub Actions Automation

### Workflow Configuration

The workflow (`.github/workflows/api-snapshot.yml`) runs:
- **Scheduled**: Daily at 2 AM UTC
- **Manual**: Via workflow_dispatch trigger

### Secrets Required

Configure these in GitHub repository settings:
- `IRACING_USERNAME`: Your iRacing account username
- `IRACING_PASSWORD`: Your iRacing account password

### Workflow Steps

1. **Checkout** repository with full git history
2. **Build** the solution
3. **Compare** current API responses with snapshots
4. **Detect** changes and generate report
5. **Update** snapshots if changes found
6. **Commit** updated snapshots to git
7. **Create** GitHub Issue with change report
8. **Upload** change report as artifact

### Issue Creation

When changes are detected, an automated issue is created with:
- Timestamp in title
- Full change report in markdown
- Summary of change types
- Detailed property-level changes
- Action items for maintainers
- Labels: `api-change`, `automated`

## Change Reports

Reports are saved to `snapshots/change-report-YYYY-MM-DD-HHmmss.md` and include:

```markdown
# iRacing API Snapshot Change Report

**Report Generated:** 2025-01-09 02:05:23 UTC
**Endpoints Checked:** 72
**Endpoints with Changes:** 3

## Summary

- 🆕 **NewEndpoint**: 1 endpoint(s)
- 🔄 **ModifiedResponse**: 2 endpoint(s)

## Detailed Changes

### 🆕 GetNewFeature
**Change Type:** NewEndpoint

### 🔄 GetCars
**Change Type:** ModifiedResponse

**Property Changes:**
- **$.cars[0].rainEnabled**
  - New property added
  - New: `true`
```

## Snapshot File Structure

Snapshots are stored in `snapshots/*.snapshot.json`:

```json
{
  "endpoint": "/data/car/get",
  "method": "GetCars",
  "timestamp": "2025-01-09T02:05:23.1234567Z",
  "success": true,
  "responseJson": "{ ... }",
  "statusCode": 200
}
```

## Maintenance

### Updating Baseline

When API changes are expected (e.g., after iRacing updates):

1. Review the change report
2. Update wrapper models if needed
3. Update tests
4. Re-run `CaptureApiSnapshots` to update baseline
5. Commit new snapshots

### Handling False Positives

Some endpoints return dynamic data (timestamps, session IDs). If these cause noise:

1. Update the comparer to ignore specific paths
2. Or filter these endpoints from snapshot testing

### Troubleshooting

**Test fails with "No existing snapshots found"**
- Run `CaptureApiSnapshots` first to create baseline

**Authentication errors**
- Verify environment variables are set
- Ensure Legacy Authentication is enabled in iRacing account

**Rate limiting**
- The wrapper has built-in rate limit handling
- If issues persist, add delays between endpoint calls

## Development

### Adding Custom Snapshot Logic

To customize how specific endpoints are captured:

1. Modify `CaptureEndpointAsync()` in `ApiSnapshotTests.cs`
2. Add endpoint-specific parameter logic
3. Update `GetDefaultParameterValue()` for better defaults

### Extending Change Detection

To detect specific types of changes:

1. Modify `CompareJsonElements()` in `SnapshotComparer.cs`
2. Add custom comparison logic for specific patterns
3. Update `ChangeType` enum for new change categories

## File Organization

```
Frenetik.iRacingApiWrapper.SnapshotTests/
├── Infrastructure/
│   ├── Snapshot.cs                  # Snapshot data model
│   ├── SnapshotManager.cs          # File I/O operations
│   ├── SnapshotComparer.cs         # Change detection logic
│   └── ChangeReport.cs             # Report generation
├── ApiSnapshotTests.cs             # Main test class
├── README.md                        # This file
└── Frenetik.iRacingApiWrapper.SnapshotTests.csproj

snapshots/                           # Generated snapshot files (committed to git)
├── GetCars.snapshot.json
├── GetTracks.snapshot.json
├── ...
└── change-report-*.md              # Ignored by git
```
