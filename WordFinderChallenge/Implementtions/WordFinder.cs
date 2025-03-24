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

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            if (wordstream == null) throw new ArgumentNullException(nameof(wordstream));

            var uniqueWords = new HashSet<string>(wordstream.Distinct(StringComparer.OrdinalIgnoreCase), StringComparer.OrdinalIgnoreCase);
            var foundWords = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var word in uniqueWords)
            {
                int count = CountOccurrences(word.Trim());
                if (count > 0)
                    foundWords[word.Trim()] = count;
            }

            return foundWords
                .OrderByDescending(kvp => kvp.Value)
                .ThenBy(kvp => kvp.Key)
                .Take(10)
                .Select(kvp => kvp.Key);
        }

        private int CountOccurrences(string word)
        {
            int count = 0;

            foreach (var row in _rows)
                count += CountSubstringOccurrences(row, word);

            foreach (var column in _columns)
                count += CountSubstringOccurrences(column, word);

            return count;
        }

        private int CountSubstringOccurrences(string text, string word)
        {
            int count = 0;
            int index = 0;

            while ((index = text.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }

            return count;
        }

        private List<string> BuildColumns(IReadOnlyList<string> rows)
        {
            int rowCount = rows.Count;
            int colCount = rows[0].Length;
            var columns = new List<string>(colCount);

            for (int col = 0; col < colCount; col++)
            {
                char[] colChars = new char[rowCount];
                for (int row = 0; row < rowCount; row++)
                    colChars[row] = rows[row][col];
                columns.Add(new string(colChars));
            }

            return columns;
        }
    }
}
