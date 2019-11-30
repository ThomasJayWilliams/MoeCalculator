using System.Collections.Generic;
using System.Linq;

namespace MoeCalculator
{
    public static class LinqExtensions
    {
        public static bool IsNull<T>(this IEnumerable<T> source) =>
            source == null || !source.Any();

        public static bool IsFilledWithNulls<T>(this IEnumerable<T> source) =>
            source.All(i => i == null);
    }
}