using UniqueWordsCounter.Services;
using UniqueWordsCounter.Services.Impl;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter input file path: ");
        var filePath = ReadFilePathAndValidate();

        Console.WriteLine("Enter result file path: ");
        var resultFilePath = ReadFilePathAndValidate();


        IAppService appService = new AppService();
        appService.Run(filePath, resultFilePath);

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
