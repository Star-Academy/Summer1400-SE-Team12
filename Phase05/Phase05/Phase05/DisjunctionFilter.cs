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
        
        public ISet<string> Filter(ISet<string> minusQueries)
        {
            var minusFiltered = new HashSet<string>();
            foreach (var s in minusQueries.Select(query => _invertedIndex.GetInvertedIndexValue(query)).SelectMany(set => set))
            {
                minusFiltered.Add(s);
            }
            return minusFiltered;
        }
        
    }
}