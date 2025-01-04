using System.Runtime.Serialization;

namespace Frenetik.iRacingApiWrapper.Extensions;
internal static class EnumExtensions
{
    public static string GetEnumMemberValue(this Enum value)
    {
        var type = value.GetType();
        var memberInfos = type.GetMember(value.ToString());
        var enumMember = memberInfos[0].GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
        return enumMember?.Value ?? value.ToString();
    }
}
