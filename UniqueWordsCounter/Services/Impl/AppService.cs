using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWordsCounter.Services.Impl
{
    internal class AppService : IAppService
    {
        public void Run(string filePath, string resultFilePath)
        {
            var keyValuePairs = new Dictionary<string, int>();
            var lines = File.ReadLines(filePath);

            foreach (var line in lines)
            {
                var words = line.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';', '-' },
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (!keyValuePairs.ContainsKey(word))
                    {
                        keyValuePairs.Add(word, 1);
                    }
                    else
                    {
                        keyValuePairs[word]++;
                    }
                }
            }

            using var sw = new StreamWriter(resultFilePath);
            foreach (var row in keyValuePairs.OrderByDescending(x => x.Value))
            {
                sw.WriteLine($"{row.Key}, {row.Value}");
            }
        }
    }
}
