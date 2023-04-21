namespace UniqueWordsCounter.Services.Impl
{
    public class TxtFileParser : IFileParser
    {
        private readonly string filePath;

        public TxtFileParser(string filePath)
        {
            this.filePath = filePath;
        }
        public IEnumerable<string> GetLines()
        {
            return File.ReadLines(filePath).ToList();
        }
    }
}
