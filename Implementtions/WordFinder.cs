using WordFinderChallenge.Extensions;
using WordFinderChallenge.Interfaces;

namespace WordFinderChallenge.Implementtions
{
    public class WordFinder : IWordFinder
    {
        private readonly IReadOnlyList<string> _rows;
        private readonly IReadOnlyList<string> _columns;

        public WordFinder(IEnumerable<string> matrix)
        {
            matrix.ValidateMatrix();
            _rows = matrix.Select(row => row.Trim()).ToList();
            _columns = BuildColumns(_rows);
        }

        private IReadOnlyList<string>? BuildColumns(IReadOnlyList<string> rows)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            ArgumentNullException.ThrowIfNull(wordstream);

            var uniqueWords = new HashSet<string>(wordstream.Distinct(StringComparer.OrdinalIgnoreCase), StringComparer.OrdinalIgnoreCase);
            var foundWords = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var word in uniqueWords)
            {
                int count = CountOccurrences(word);
                if (count > 0)
                    foundWords[word] = count;
            }

            return foundWords
                .OrderByDescending(kvp => kvp.Value)
                .Take(10)
                .Select(kvp => kvp.Key);
        }

        private int CountOccurrences(string word)
        {
            throw new NotImplementedException();
        }
    }
}
