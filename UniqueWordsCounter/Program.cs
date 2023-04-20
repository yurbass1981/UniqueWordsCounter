using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter input file path: ");
        var filePath = ReadFilePathAndValidate();

        Console.WriteLine("Enter result file path: ");
        var resultFilePath = ReadFilePathAndValidate();


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

        using var sw = new StreamWriter(resultPath);
        foreach (var row in keyValuePairs.OrderByDescending(x => x.Value))
        {
            sw.WriteLine($"{row.Key}, {row.Value}");
        }

        Console.ReadKey();
    }

    private static string ReadFilePathAndValidate()
    {
        var path = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(path) || path.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)
        {
            Console.WriteLine("File path is incorrect, please try again.");
            ReadFilePathAndValidate();
        }

        if (!File.Exists(path))
        {
            Console.WriteLine($"File with path {path} hasn't been found, please try again.");
            ReadFilePathAndValidate();
        }

        return path!;
    }
}
