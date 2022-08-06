using System;

namespace JlMetroidvaniaProject.FSM
{
    public static partial class EnumExtension
    {
        public static int ToInt32(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }
    }
}