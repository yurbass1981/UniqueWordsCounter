namespace UniqueWordsCounter.Services.Impl
{
    public static class FileParserFactory
    {
        public static IFileParser GetInstance(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath);

            return fileExtension switch
            {
                ".txt" => new TxtFileParser(filePath),
                _ => throw new Exception($"File with extension {fileExtension} isn't supported")
            };
        }
    }
}
