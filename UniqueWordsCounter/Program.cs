using System;

class Program
{
    static void Main(string[] args)
    {
        const string path = @"C:\Users\Yurii Iliushin\Desktop\1\repka.txt";


        var keyValuePairs = new Dictionary<string, int>();
        var lines = File.ReadLines(path);

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

        using var sw = new StreamWriter(@"C:\Users\Yurii Iliushin\Desktop\1\result.txt");
        foreach (var row in keyValuePairs.OrderByDescending(x => x.Value))
        {
            sw.WriteLine($"{row.Key}, {row.Value}");
        }

        Console.ReadKey();
    }
}
