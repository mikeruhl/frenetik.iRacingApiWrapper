using System.Runtime.Serialization;

namespace Frenetik.iRacingApiWrapper.Enums;

/// <summary>
/// Values for sorting league search results.
/// </summary>
public enum LeagueSortValue
{
    /// <summary>
    /// Sort by relevance to the search query.
    /// </summary>
    [EnumMember(Value = "relevance")]
    Relevance,
    /// <summary>
    /// Sort by league name.
    /// </summary>
    [EnumMember(Value = "leaguename")]
    LeagueName,
    /// <summary>
    /// Sort by display name.
    /// </summary>
    [EnumMember(Value = "displayname")]
    DisplayName,
    /// <summary>
    /// Sort by the number of members in the roster.
    /// </summary>
    [EnumMember(Value = "rostercount")]
    RosterCount
}
