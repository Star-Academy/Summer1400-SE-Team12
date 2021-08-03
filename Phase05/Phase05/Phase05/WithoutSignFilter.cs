using System.Collections.Generic;

namespace Phase05
{
    public class WithoutSignFilter : IFilter
    {
        private readonly IInvertedIndex _invertedIndex;

        public WithoutSignFilter(IInvertedIndex invertedIndex)
        {
            _invertedIndex = invertedIndex;
        }
        public HashSet<string> Filter(HashSet<string> signQueries)
        {
            throw new System.NotImplementedException();
        }
        
    }
}