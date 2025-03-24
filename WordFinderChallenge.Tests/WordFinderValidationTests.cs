using FluentAssertions;
using WordFinderChallenge.Extensions;

namespace WordFinderChallenge.Tests
{
    public class MatrixValidationExtensionsTests
    {
        [Fact]
        public void ValidateNotNull_ShouldThrow_WhenMatrixIsNull()
        {
            IEnumerable<string> matrix = null;

            Action act = () => matrix.ValidateNotNull();

            act.Should().Throw<ArgumentNullException>()
               .WithMessage("*Matrix cannot be null*");
        }

        [Fact]
        public void ValidateNotEmpty_ShouldThrow_WhenMatrixIsEmpty()
        {
            var matrix = new List<string>();

            Action act = () => matrix.ValidateNotEmpty();

            act.Should().Throw<ArgumentException>()
               .WithMessage("Matrix must contain at least one row.");
        }

        [Fact]
        public void ValidateUniformRowLengths_ShouldThrow_WhenRowsHaveDifferentLengths()
        {
            var matrix = new List<string>
            {
                "abcde",
                "abcd",
                "abcde"
            };

            Action act = () => matrix.ValidateUniformRowLengths();

            act.Should().Throw<ArgumentException>()
               .WithMessage("All rows in the matrix must have the same length.");
        }

        [Fact]
        public void ValidateMaxSize_ShouldThrow_WhenRowCountExceedsMax()
        {
            var matrix = new List<string>();
            for (int i = 0; i < 65; i++)
                matrix.Add("abcde");

            Action act = () => matrix.ValidateMaxSize();

            act.Should().Throw<ArgumentException>()
               .WithMessage("Matrix cannot have more than 64 rows.");
        }

        [Fact]
        public void ValidateMaxSize_ShouldThrow_WhenColumnCountExceedsMax()
        {
            var longRow = new string('a', 65);
            var matrix = new List<string> { longRow, longRow };

            Action act = () => matrix.ValidateMaxSize();

            act.Should().Throw<ArgumentException>()
               .WithMessage("Matrix cannot have more than 64 columns.");
        }

        [Fact]
        public void ValidateOnlyLetters_ShouldThrow_WhenMatrixContainsNonAlphabeticCharacters()
        {
            var matrix = new List<string>
            {
                "abcde",
                "12345", // invalid characters
                "fghij"
            };

            Action act = () => matrix.ValidateOnlyLetters();

            act.Should().Throw<ArgumentException>()
               .WithMessage("Matrix must contain only alphabetic characters.");
        }

        [Fact]
        public void ValidateMatrix_ShouldThrow_WhenMatrixViolatesMultipleRules()
        {
            var matrix = new List<string>
            {
                "abcde",
                "abcd",   // different length
                "abc1e"   // invalid character
            };

            Action act = () => matrix.ValidateMatrix();

            act.Should().Throw<ArgumentException>()
               .WithMessage("All rows in the matrix must have the same length.");
        }

        [Fact]
        public void ValidateMatrix_ShouldPass_WhenMatrixIsValid()
        {
            var matrix = new List<string>
            {
                "abcde",
                "fghij",
                "klmno"
            };

            Action act = () => matrix.ValidateMatrix();

            act.Should().NotThrow();
        }
    }
}
