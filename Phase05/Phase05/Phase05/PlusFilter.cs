using System.Collections.Generic;

namespace Phase05
{
    public class PlusFilter : IFilter
    {
        private readonly IInvertedIndex _invertedIndex;

        public PlusFilter(IInvertedIndex invertedIndex)
        {
            _invertedIndex = invertedIndex;
        }

        public HashSet<string> Filter(HashSet<string> signQueries)
        {
            throw new System.NotImplementedException();
        }

        
    }
}