using WordFinderChallenge.Extensions;
using WordFinderChallenge.Interfaces;

namespace WordFinderChallenge.Implementtions
{
    internal class WordFinder : IWordFinder
    {
        private readonly int _rows;
        private readonly int _cols;

        public WordFinder(IEnumerable<string> matrix)
        {
             //Perform Validations via Extensions:
             // - matrix not null,
             matrix.CheckNullMatrix();

             // - list not empty,
             var matrixList = matrix.ToList();
             matrixList.CheckEmptyList();
             
            // - all rows have the same length
            _cols = matrixList[0].Length;
            _rows = matrixList.Count;
            matrixList.CheckLength(_cols);

            // Decide data structure


        }
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            throw new NotImplementedException();
        }
    }
}
