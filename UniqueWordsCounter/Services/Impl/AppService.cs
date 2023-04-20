using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWordsCounter.Services.Impl
{
    internal class AppService : IAppService
    {
        private readonly char[] _separators = { ' ', ',', '.', '!', '?', ':', ';', '-', '*' };

        public void Run(string filePath, string resultFilePath)
        {
            var uniqueWordsCountMap = GetUniqueWordsCountMapFromFile(filePath);
            WriteResultToFile(resultFilePath, uniqueWordsCountMap);
        }

        private Dictionary<string, int> GetUniqueWordsCountMapFromFile(string filePath)
        {
            var uniqueWordsCountMap = new Dictionary<string, int>();

            var lines = File.ReadLines(filePath);
                

            foreach (var line in lines)
            {
                var words = line.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (!uniqueWordsCountMap.ContainsKey(word))
                    {
                        uniqueWordsCountMap.Add(word, 1);
                    }
                    else
                    {
                        uniqueWordsCountMap[word]++;
                    }
                }
            }

            return uniqueWordsCountMap;
        }

        private static void WriteResultToFile(string resultFilePath, Dictionary<string, int> uniqueWordsCountMap)
        {
            using var sw = new StreamWriter(resultFilePath);
            sw.WriteLine("Word | Count of usage");

            foreach (var row in uniqueWordsCountMap.OrderByDescending(r => r.Value))
                sw.WriteLine($"{row.Key} | {row.Value}");
        }
    }
}
