using System;
using System.Linq;

namespace MoeCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arg = args.FirstOrDefault();
            var calc = new Calculator();

            if (string.IsNullOrEmpty(arg))
            {
                var calcTask = calc.CalculateAsync(int.MaxValue);

                calcTask.Wait();
                calcTask.Result.PrintFormatted();
            }

            else
            {
                if (!int.TryParse(arg, out var limiter))
                {
                    Console.WriteLine("Only numbers allowed as arguments.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                var calcTask = calc.CalculateAsync(limiter);

                calcTask.Wait();
                calcTask.Result.PrintFormatted();
            }
        }
    }
}
