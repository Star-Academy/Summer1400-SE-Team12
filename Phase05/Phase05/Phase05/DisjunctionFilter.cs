using System.Collections.Generic;
using System.Linq;

namespace Phase05
{
    public class DisjunctionFilter : IFilter
    {
        private readonly IInvertedIndex _invertedIndex;

        public DisjunctionFilter(IInvertedIndex invertedIndex)
        {
            _invertedIndex = invertedIndex;
        }
        
        public ISet<string> Filter(ISet<string> minusOrPlusQueries)
        {
            var disjunctionFiltered = new HashSet<string>();

            return minusOrPlusQueries.Aggregate(disjunctionFiltered, (current, query) =>
                current.Union(_invertedIndex.GetInvertedIndexValue(query)).ToHashSet());
        }
        
    }
}