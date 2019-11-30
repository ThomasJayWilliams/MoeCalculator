using System;
using System.Linq;

namespace MoeCalculator
{
    public static class ElementExtensions
    {
        public static ConsoleColor GetColor(this Element element)
        {            
            var enumType = typeof(Element);
            var memberInfos = enumType.GetMember(element.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes = 
                enumValueMemberInfo.GetCustomAttributes(typeof(OutputColorAttribute), false);
            return ((OutputColorAttribute)valueAttributes.First()).Color;
        }
    }
}