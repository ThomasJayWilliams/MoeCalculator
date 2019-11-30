using System;

namespace MoeCalculator
{
    public static class ConsoleHelper
    {
        private static readonly object _lockObj = new object();

        public static void WriteColored(object value, ConsoleColor color)
        {
            lock(_lockObj)
            {
                var currentColor = Console.ForegroundColor;

                Console.ForegroundColor = color;
                Console.Write(value);
                Console.ForegroundColor = currentColor;
            }
        }
        public static void WriteColoredLine(object value, ConsoleColor color)
        {
            lock(_lockObj)
            {
                var currentColor = Console.ForegroundColor;

                Console.ForegroundColor = color;
                Console.WriteLine(value);
                Console.ForegroundColor = currentColor;
            }
        }
    }
}