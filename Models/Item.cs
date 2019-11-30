namespace MoeCalculator
{
    public sealed class Item
    {
        public string Name { get; set; }

        public byte Value { get; set; }

        public Element Element { get; set; }

        public Category Category { get; set; }

        public override string ToString() =>
            $"{Name} - {Value}, {Element}, {Category}";
    }
}