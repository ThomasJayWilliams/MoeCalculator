using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace MoeCalculator
{
    public sealed class DataReader
    {
        public async Task<List<Item>> GetItemsAsync(string path)
        {
            var json = await File.ReadAllTextAsync(path, Encoding.Default)
                .ConfigureAwait(false);

            if (string.IsNullOrEmpty(json))
                throw new InvalidDataException("JSON cannot be empty.");

            var items = JsonConvert.DeserializeObject<List<Item>>(json);

            if (items == null || !items.Any())
                throw new InvalidDataException("Unable to cast JSON data.");

            return items;
        }
    }
}