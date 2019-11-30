using CommandLine;

namespace MoeCalculator
{
    public class Options
    {
        [Option('d', "difference", Required = false, HelpText = "Sets preffered average difference between element totals.")]
        public int SuggestedDifference { get; set; }

        [Option('m', "min-total", Required = false, HelpText = "Sets minimal summary total value of the result set.")]
        public int MinimalTotalValue { get; set; }

        [Option("include-ninjutsu", Required = false, HelpText = "Specifies wheither should ninjutsu be included in calculation or not.")]
        public bool IncludeNinjutsu { get; set; }
    }
}