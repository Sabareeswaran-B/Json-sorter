using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonSorter
{
    public class SortService
    {
        public async Task<Dictionary<string, object>> SortAsync(string json)
        {
            var configurations = JsonConvert
                .DeserializeObject<Dictionary<string, object>>(json);

            var sortedConfigurations = configurations
                .OrderBy(_ => _.Key)
                .ToDictionary(_ => _.Key, _ => _.Value);

            foreach (var configuration in configurations)
            {
                try
                {
                    var nestedConfig = await this.SortAsync(configuration.Value.ToString());

                    sortedConfigurations[configuration.Key] = nestedConfig;
                }
                catch (Exception)
                {
                }
            }

            return await Task.FromResult(sortedConfigurations);
        }
    }
}
