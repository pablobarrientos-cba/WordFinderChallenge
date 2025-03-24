using FluentAssertions;
using WordFinderChallenge.Implementtions;

namespace WordFinderChallenge.Tests
{
    public class WordFinderFindTests
    {
        [Fact]
        public void Find_ShouldReturnExactMatchHorizontally()
        {
            var matrix = new List<string>
            {
                "chill",
                "xxxxx",
                "xxxxx",
                "xxxxx",
                "xxxxx"
            };

            var wordstream = new List<string> { "chill" };

            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);

            result.Should().ContainSingle().Which.Should().Be("chill");
        }

        [Fact]
        public void Find_ShouldReturnExactMatchVertically()
        {
            var matrix = new List<string>
            {
                "cxxxx",
                "hxxxx",
                "ixxxx",
                "lxxxx",
                "lxxxx"
            };

            var wordstream = new List<string> { "chill" };

            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);

            result.Should().ContainSingle().Which.Should().Be("chill");
        }

        [Fact]
        public void Find_ShouldIgnoreCaseSensitivity()
        {
            var matrix = new List<string>
            {
                "CHILL",
                "xxxxx",
                "xxxxx",
                "xxxxx",
                "xxxxx"
            };

            var wordstream = new List<string> { "chill" };

            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);

            result.Should().Contain("chill");
        }

        [Fact]
        public void Find_ShouldReturnEmpty_WhenNoWordsMatch()
        {
            var matrix = new List<string>
            {
                "aaaaa",
                "bbbbb",
                "ccccc",
                "ddddd",
                "eeeee"
            };

            var wordstream = new List<string> { "notfound", "stillnotfound" };

            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);

            result.Should().BeEmpty();
        }

        [Fact]
        public void Find_ShouldHandleEmptyWordStream()
        {
            var matrix = new List<string>
            {
                "aaaaa",
                "bbbbb",
                "ccccc"
            };

            var wordstream = new List<string>();

            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);

            result.Should().BeEmpty();
        }

        [Fact]
        public void Find_ShouldNotCountDuplicatesFromWordStream()
        {
            var matrix = new List<string>
            {
                "hello",
                "hello",
                "hello"
            };

            var wordstream = new List<string> { "hello", "hello", "hello" };

            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);

            result.Should().ContainSingle().Which.Should().Be("hello");
        }

        [Fact]
        public void Find_ShouldReturnTop10Words()
        {
            var matrix = Enumerable.Repeat("match", 15).ToList();

            var wordstream = Enumerable.Range(1, 20).Select(i => $"match{i}").ToList();
            wordstream[0] = "match"; // only one match

            matrix[0] = "match";

            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);

            result.Should().HaveCount(1);
            result.Should().Contain("match");
        }

        [Fact]
        public void Find_ShouldSortByFrequency_ThenAlphabetically()
        {
            var matrix = new List<string>
            {
                "alpha",
                "bravo",
                "bravo",
                "charl",
                "charl",
                "charl",
                "delta",
                "echoo",
                "foxtt",
                "golfx",
                "hotel",
                "india"
            };

            var wordstream = new List<string>
            {
                "alpha", "bravo", "charl", "delta",
                "echoo", "foxtt", "golfx", "hotel",
                "india", "alpha", "bravo", "charl",
                "charl", "bravo", "alpha"
            };

            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream).ToList();

            result.Should().HaveCount(9);
            result[0].Should().Be("charl"); // 3 matches
            result[1].Should().Be("bravo"); // 2 matches
            result[2].Should().Be("alpha"); // 1 match
        }

        [Fact]
        public void Find_ShouldHandleWhitespaceWordsGracefully()
        {
            var matrix = new List<string>
            {
                "world",
                "xxxxx",
                "xxxxx",
                "xxxxx",
                "xxxxx"
            };

            var wordstream = new List<string> { " world ", "  world" };

            var finder = new WordFinder(matrix);
            var result = finder.Find(wordstream);

            result.Should().ContainSingle().Which.Should().Be("world"); // original word is returned trimmed
        }
    }
}
