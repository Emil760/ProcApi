using System.ComponentModel;

namespace ProcApi.Application.Utility
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var memberInfo = type.GetMember(enumValue.ToString());

            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                    return ((DescriptionAttribute)attributes[0]).Description;
            }

            return enumValue.ToString();
        }
    }
}
