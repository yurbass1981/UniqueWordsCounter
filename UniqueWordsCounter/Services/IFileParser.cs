namespace UniqueWordsCounter.Services
{
    public interface IFileParser
    {
        IEnumerable<string> GetLines();
    }
}
