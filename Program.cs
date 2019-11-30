using System;
using CommandLine;

namespace MoeCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(Run);
        }

        public static void Run(Options opts)
        {
            var calc = new Calculator();
            var calcTask = calc.CalculateAsync(opts);

            calcTask.Wait();
            calcTask.Result.PrintFormatted();
        }
    }
}
