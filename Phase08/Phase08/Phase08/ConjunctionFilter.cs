using System.Collections.Generic;
using System.Linq;

namespace Phase08
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
                _invertedIndex.GetInvertedIndexValue(signQueries.First()));

            return signQueries.Aggregate(conjunctionFiltered, (current, query) =>
                current.Intersect(_invertedIndex.GetInvertedIndexValue(query))
                    .ToHashSet());
        }
    }
}