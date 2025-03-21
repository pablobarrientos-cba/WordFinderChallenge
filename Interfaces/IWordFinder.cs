namespace WordFinderChallenge.Interfaces
{
    public interface IWordFinder
    {
        public IEnumerable<string> Find(IEnumerable<string> wordstream);
    }
}
