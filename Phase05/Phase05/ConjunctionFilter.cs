using System.Collections.Generic;
using System.Linq;

namespace Phase05
{
    public class ConjunctionFilter : IFilter
    {
        private readonly IInvertedIndex _invertedIndex;

        public ConjunctionFilter(IInvertedIndex invertedIndex)
        {
            _invertedIndex = invertedIndex;
        }

        public ISet<string> Filter(ISet<string> signQueries)
        {
            ISet<string> conjunctionFiltered = new HashSet<string>(
                _invertedIndex.GetValueOfInvertedIndexKey(signQueries.First()));

            return signQueries.Aggregate(conjunctionFiltered, (current, query) =>
                current.Intersect(_invertedIndex.GetValueOfInvertedIndexKey(query))
                    .ToHashSet());
        }
    }
}