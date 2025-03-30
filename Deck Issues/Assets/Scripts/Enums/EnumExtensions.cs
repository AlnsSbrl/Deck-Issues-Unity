using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Enums
{
    public static class EnumExtensions
    {
        public static SpanishSuit GetSpanishSuit<T>(this T enumValue)
        {
            FieldInfo fieldInfo = typeof(T).GetField(enumValue.ToString());
            if(fieldInfo != null)
            {
                EnumValueAttribute attribute = (EnumValueAttribute) Attribute.GetCustomAttribute(fieldInfo, typeof(EnumValueAttribute));
                return attribute?.GetSpanishSuit() ?? SpanishSuit.NONE;
            }
            return SpanishSuit.NONE;
        }

        public static int GetCardValue<T>(this T enumValue)
        {
            FieldInfo fieldInfo = typeof (T).GetField(enumValue.ToString());
            if(fieldInfo != null)
            {
                EnumValueAttribute attribute = (EnumValueAttribute) Attribute.GetCustomAttribute(fieldInfo,typeof(EnumValueAttribute));
                return attribute?.GetCardValue() ?? 0;
            }
            return 0;
        }
    }
}
