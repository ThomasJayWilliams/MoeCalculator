using System;

namespace MoeCalculator
{
    public sealed class Item : ICloneable
    {
        public string Name { get; set; }

        public byte Value { get; set; }

        public Element Element { get; set; }

        public Category Category { get; set; }

        public object Clone() =>
            new Item
            {
                Category = this.Category,
                Element = this.Element,
                Name = this.Name.Clone().ToString(),
                Value = this.Value
            };

        public void PrintFormatted()
        {
            ConsoleHelper.WriteColored($"\t{this.Element}", this.Element.GetColor());
            Console.Write($"\t{this.Value}");
            Console.WriteLine($"\t{this.Category}\t{this.Name}");            
        }
    }
}