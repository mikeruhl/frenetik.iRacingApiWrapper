using System.Runtime.Serialization;

namespace Frenetik.iRacingApiWrapper.Enums;
public enum SortOrder
{
    [EnumMember(Value = "asc")]
    Asc,
    [EnumMember(Value = "desc")]
    Desc
}
