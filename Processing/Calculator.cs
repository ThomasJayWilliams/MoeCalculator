using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MoeCalculator
{
    public sealed class Calculator
    {
        private readonly DataReader _dataReader;

        public Calculator()
        {
            _dataReader = new DataReader();
        }

        public async Task<ItemSet> CalculateAsync(Options options)
        {
            var items = await _dataReader.GetItemsAsync(
                Path.Combine(Directory.GetCurrentDirectory(), "Data/items.json"));

            if (items.IsNull() || items.IsFilledWithNulls())
            {
                Console.WriteLine("Error deserializing items.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            return GenerateAndCalculate(items, options);
        }

        private ItemSet GenerateAndCalculate(List<Item> items, Options options)
        {
            if (options.SuggestedDifference <= 0)
                options.SuggestedDifference = int.MaxValue;

            var result = new ItemSet();
            var itemsByCategories = Enum.GetValues(typeof(Category))
                .Cast<Category>()
                .Select(e => new List<Item>(items.Where(i => i.Category == e)))
                .ToList();

            var temp = new ItemSet();

            foreach (var cat1Item in itemsByCategories[0])
            {
                temp.AddOrReplace(cat1Item);
                
                foreach (var cat2Item in itemsByCategories[1])
                {
                    temp.AddOrReplace(cat2Item);
                
                    foreach (var cat3Item in itemsByCategories[2])
                    {
                        temp.AddOrReplace(cat3Item);

                        foreach (var cat4Item in itemsByCategories[3])
                        {
                            temp.AddOrReplace(cat4Item);

                            foreach (var cat5Item in itemsByCategories[4])
                            {
                                temp.AddOrReplace(cat5Item);

                                foreach (var cat6Item in itemsByCategories[5])
                                {
                                    temp.AddOrReplace(cat6Item);

                                    foreach (var cat7Item in itemsByCategories[6])
                                    {
                                        temp.AddOrReplace(cat7Item);

                                        foreach (var cat8Item in itemsByCategories[7])
                                        {
                                            temp.AddOrReplace(cat8Item);

                                            foreach (var cat9Item in itemsByCategories[8])
                                            {
                                                temp.AddOrReplace(cat9Item);

                                                foreach (var cat10Item in itemsByCategories[9])
                                                {
                                                    temp.AddOrReplace(cat10Item);

                                                    foreach (var cat11Item in itemsByCategories[10])
                                                    {
                                                        temp.AddOrReplace(cat11Item);

                                                        var resultAvg = result.GetAverageDifference();
                                                        var resultTotal = result.GetTotalValue();
                                                        var tempTotal = temp.GetTotalValue();
                                                        var tempAvg = temp.GetAverageDifference();

                                                        if ((tempAvg <= options.SuggestedDifference || tempAvg <= resultAvg)
                                                            && tempTotal >= resultTotal && tempTotal >= options.MinimalTotalValue)
                                                            result = temp.Clone() as ItemSet;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}