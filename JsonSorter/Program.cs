using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonSorter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Initilizing JSON sorter.....");

                Console.WriteLine("Enter the JSON file path");

                var path = Console.ReadLine();

                var json = await File.ReadAllTextAsync(path);

                var sortService = new SortService();

                Console.WriteLine("Sorting the JSON.....");

                var sortedConfigurations = await sortService.SortAsync(json);

                Console.WriteLine("Writing the sorted JSON into the same file.....");

                File.WriteAllText(path, JsonConvert.SerializeObject(sortedConfigurations, Formatting.Indented));

                Console.WriteLine("Sorting completed.....");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
