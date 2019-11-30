using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using System.Text;

namespace MoeCalculator
{
    public sealed class ItemSet : IEnumerable<Item>, ICloneable
    {
        private readonly int ItemLimit = 11;

        private readonly IDictionary<Category, Item> _items = new Dictionary<Category, Item>();

        public ItemSet()
        {
            ItemLimit = Enum.GetValues(typeof(Category)).Length;
        }

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

        public int GetElementTotalValue(Element elem)
        {
            if (_items.IsNull() || _items.IsFilledWithNulls())
                return 0;

            return _items.Where(i => i.Value.Element == elem).Sum(i => i.Value.Value);
        }

        public List<int> GetElementTotalValues()
        {
            var elements = Enum.GetValues(typeof(Element)).Cast<Element>();

            return elements.Select(e => GetElementTotalValue(e))
                .ToList();
        }

        #endregion

        public void PrintFormatted()
        {
            if (!_items.Values.Any())
            {
                Console.WriteLine("No item set generated.");

                return;
            }

            Console.WriteLine();
            Console.WriteLine("Items:");

            foreach (var item in _items.Values)
                item.PrintFormatted();

            Console.WriteLine($"\nTotal value: {GetTotalValue()}\n");

            ConsoleHelper.WriteColored("\tFlame total", Element.Flame.GetColor());
            Console.WriteLine($": {GetElementTotalValue(Element.Flame)}");

            ConsoleHelper.WriteColored("\tIce total", Element.Ice.GetColor());
            Console.WriteLine($": {GetElementTotalValue(Element.Ice)}");

            ConsoleHelper.WriteColored("\tThunder total", Element.Thunder.GetColor());
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
                result.AddOrReplace(item.Clone() as Item);

            return result;
        }
    }
}