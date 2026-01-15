using System.Runtime.Serialization;

namespace Frenetik.iRacingApiWrapper.Enums;
/// <summary>
/// Sort order direction.
/// </summary>
public enum SortOrder
{
    /// <summary>
    /// Ascending order (lowest to highest).
    /// </summary>
    [EnumMember(Value = "asc")]
    Asc,
    /// <summary>
    /// Descending order (highest to lowest).
    /// </summary>
    [EnumMember(Value = "desc")]
    Desc
}
