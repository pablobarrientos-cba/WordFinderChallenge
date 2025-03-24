namespace WordFinderChallenge.Extensions
{
    public static class MatrixValidationExtensions
    {
        public static void ValidateNotNull(this IEnumerable<string> matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null.");
        }

        public static void ValidateNotEmpty(this IEnumerable<string> matrix)
        {
            if (!matrix.Any())
                throw new ArgumentException("Matrix must contain at least one row.");
        }

        public static void ValidateUniformRowLengths(this IEnumerable<string> matrix)
        {
            var list = matrix.ToList();
            int expectedLength = list[0].Length;

            if (list.Any(row => row.Length != expectedLength))
                throw new ArgumentException("All rows in the matrix must have the same length.");
        }

        public static void ValidateMaxSize(this IEnumerable<string> matrix, int maxRows = 64, int maxCols = 64)
        {
            var list = matrix.ToList();

            if (list.Count > maxRows)
                throw new ArgumentException($"Matrix cannot have more than {maxRows} rows.");

            if (list[0].Length > maxCols)
                throw new ArgumentException($"Matrix cannot have more than {maxCols} columns.");
        }

        public static void ValidateOnlyLetters(this IEnumerable<string> matrix)
        {
            if (matrix.Any(row => row.Any(c => !char.IsLetter(c))))
                throw new ArgumentException("Matrix must contain only alphabetic characters.");
        }

        public static void ValidateMatrix(this IEnumerable<string> matrix)
        {
            matrix.ValidateNotNull();
            matrix.ValidateNotEmpty();
            matrix.ValidateUniformRowLengths();
            matrix.ValidateMaxSize();
            matrix.ValidateOnlyLetters();
        }
    }
}
