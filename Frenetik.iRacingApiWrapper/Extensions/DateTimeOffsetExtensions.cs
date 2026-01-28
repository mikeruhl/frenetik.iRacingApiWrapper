using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frenetik.iRacingApiWrapper.Extensions;

/// <summary>
/// Extension methods for DateTimeOffset
/// </summary>
internal static class DateTimeOffsetExtensions
{
    private const string Iso8601DateFormat = "yyyy-MM-ddTHH:mmZ";

    /// <summary>
    /// Convert nullable DateTimeOffset to ISO 8601 date string (UTC)
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static string? ToIso8601DateString(this DateTimeOffset? dto)
    {
        return dto.HasValue ? dto.Value.ToUniversalTime().ToString(Iso8601DateFormat, CultureInfo.InvariantCulture) : null;
    }
}
