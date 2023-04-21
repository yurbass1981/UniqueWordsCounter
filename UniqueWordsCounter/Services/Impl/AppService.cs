namespace UniqueWordsCounter.Services.Impl
{
    public class AppService : IAppService
    {
        private readonly char[] _separators = { ' ', ',', '.', '!', '?', ':', ';', '-', '*' };

        public void Run(string filePath, string resultFilePath)
        {
            var uniqueWords = GetUniqueWords(filePath);
            WriteResultToFile(resultFilePath, uniqueWords);
        }

        private Dictionary<string, int> GetUniqueWords(string filePath)
        {
            var uniqueWords = new Dictionary<string, int>();

            var lines = FileParserFactory.GetInstance(filePath).GetLines();

            foreach (var line in lines)
            {
                var words = line.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (!uniqueWords.ContainsKey(word))
                    {
                        uniqueWords.Add(word, 1);
                    }
                    else
                    {
                        uniqueWords[word]++;
                    }
                }
            }

            return uniqueWords;
        }

        private static void WriteResultToFile(string resultFilePath, Dictionary<string, int> uniqueWords)
        {
            using var sw = new StreamWriter(resultFilePath, false);
            sw.WriteLine("Word | Count of usage");

            foreach (var row in uniqueWords.OrderByDescending(r => r.Value))
                sw.WriteLine($"{row.Key} | {row.Value}");
        }
    }
}
