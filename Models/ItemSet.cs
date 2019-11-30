using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using System.Text;

namespace MoeCalculator
{
    public sealed class ItemSet : IEnumerable<Item>, ICloneable
    {
        private const byte ItemLimit = 11;

        private readonly IDictionary<Category, Item> _items = new Dictionary<Category, Item>();

        public ItemSet() { }

        public void AddOrReplace(Item item)
        {
            if (_items.ContainsKey(item.Category))
                _items.Remove(item.Category);

            _items.Add(item.Category, item);
        }

        #region Data Processing

        public int GetTotalValue()
        {
            if (_items.IsNull() || _items.IsFilledWithNulls())
                return 0;

            return _items.Sum(i => i.Value.Value);
        }

        public decimal GetAverageDifference()
        {
            var total1 = GetElementTotalValue(Element.Flame);
            var total2 = GetElementTotalValue(Element.Ice);
            var total3 = GetElementTotalValue(Element.Thunder);

            var diffs = new List<decimal>
            {
                Math.Abs(total2 - total1),
                Math.Abs(total3 - total1),
                Math.Abs(total1 - total2),
                Math.Abs(total3 - total2),
                Math.Abs(total1 - total3),
                Math.Abs(total2 - total3)
            };

            return diffs.Average();
        }        

        private int GetElementTotalValue(Element elem)
        {
            if (_items.IsNull() || _items.IsFilledWithNulls())
                return 0;

            return _items.Where(i => i.Value.Element == elem).Sum(i => i.Value.Value);
        }

        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("Items:");
            sb.AppendJoin("\n", _items);
            sb.AppendLine("\n");

            sb.AppendLine($"Total value: {GetTotalValue()}");
            sb.AppendLine();

            sb.AppendLine($"Flame total: {GetElementTotalValue(Element.Flame)}");
            sb.AppendLine($"Ice total: {GetElementTotalValue(Element.Ice)}");
            sb.AppendLine($"Thunder total: {GetElementTotalValue(Element.Thunder)}");

            return sb.ToString();
        }

        public void PrintFormatted()
        {
            Console.WriteLine();
            Console.WriteLine("Items:");

            foreach (var item in _items.Values)
            {
                Console.Write($"{item.Name} - {item.Value}, ");
                ConsoleHelper.WriteColored(item.Element, item.Element.GetColor());
                Console.WriteLine($", {item.Category}");
            }            

            Console.WriteLine($"Total value: {GetTotalValue()}");
            Console.WriteLine();

            ConsoleHelper.WriteColored("Flame total", Element.Flame.GetColor());
            Console.WriteLine($": {GetElementTotalValue(Element.Flame)}");

            ConsoleHelper.WriteColored("Ice total", Element.Ice.GetColor());
            Console.WriteLine($": {GetElementTotalValue(Element.Ice)}");

            ConsoleHelper.WriteColored("Thunder total", Element.Thunder.GetColor());
            Console.WriteLine($": {GetElementTotalValue(Element.Thunder)}");
        }

        #region IEnumerable<Item> Implementation

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator1();
        }

        private IEnumerator GetEnumerator1() => this.GetEnumerator();

        #endregion

        public object Clone()
        {
            var result = new ItemSet();

            foreach (var item in _items.Values)
                result.AddOrReplace(item);

            return result;
        }
    }
}