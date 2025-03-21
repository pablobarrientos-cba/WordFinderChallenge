namespace WordFinderChallenge.Extensions
{
    public static class MatrixExtensions
    {
        /// <summary>
        /// Checks for null on specified matrix
        /// </summary>
        /// <param name="matrix">A collection of strings representing rows in the character matrix</param>
        /// <exception cref="ArgumentNullException">Thrown when matrix is null</exception>
        public static void CheckNullMatrix(this IEnumerable<string> matrix)
        {
            ArgumentNullException.ThrowIfNull(matrix);
        }

        /// <summary>
        /// Checks if the collection contains elements
        /// </summary>
        /// <param name="matrix">A collection of strings representing rows in the character matrix</param>
        /// <exception cref="ArgumentException">Thrown when matrix is empty</exception>
        public static void CheckEmptyList(this IEnumerable<string> matrix) 
        {
            if (!matrix.Any())
            {
                throw new ArgumentException("Matrix cannot be empty", nameof(matrix));
            }
        }

        /// <summary>
        /// Checks that all elements have the same length
        /// </summary>
        /// <param name="matrix">A collection of strings representing rows in the character matrix</param>
        /// <param name="cols">The columns or length of a particular row</param>
        /// <exception cref="ArgumentException">Thrown when contains rows of different lengths</exception>
        public static void CheckLength (this IEnumerable<string> matrix, int cols) 
        {
            if (matrix.Any(row => row.Length != cols))
            {
                throw new ArgumentException("All rows in the matrix must have the same length", nameof(matrix));
            }
        }
    }
}
