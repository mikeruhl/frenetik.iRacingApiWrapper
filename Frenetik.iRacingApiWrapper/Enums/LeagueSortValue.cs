using System.Runtime.Serialization;

namespace Frenetik.iRacingApiWrapper.Enums;

public enum LeagueSortValue
{
    [EnumMember(Value = "relevance")]
    Relevance,
    [EnumMember(Value = "leaguename")]
    LeagueName,
    [EnumMember(Value = "displayname")]
    DisplayName,
    [EnumMember(Value = "rostercount")]
    RosterCount
}
