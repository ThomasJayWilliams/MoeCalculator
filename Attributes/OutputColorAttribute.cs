using System;

namespace MoeCalculator
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public class OutputColorAttribute : Attribute
    {
        public ConsoleColor Color { get; set; }
    }
}