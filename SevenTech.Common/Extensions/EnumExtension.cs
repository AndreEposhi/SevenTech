using System;
using System.ComponentModel;

namespace SevenTech.Common.Extensions
{
    /// <summary>
    /// Extensões para os enumeradores
    /// </summary>
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            var description = "";
            var type = value.GetType();
            var member = type.GetMember(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                description = attributes[0].Description;

            return description;
        }
    }
}