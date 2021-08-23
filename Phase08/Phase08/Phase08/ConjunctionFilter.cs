using System.Collections.Generic;
using System.Linq;
using SQLHandler;

namespace Phase08
{
    public class ConjunctionFilter : IFilter
    {
        private readonly IInvertedIndexContextWrapper _invertedIndexContextWrapper;

        public ConjunctionFilter(IInvertedIndexContextWrapper invertedIndexContextWrapper)
        {
            _invertedIndexContextWrapper = invertedIndexContextWrapper;
        }

        public ISet<string> Filter(ISet<string> signQueries)
        {
            var firstQuery = signQueries.First();
            ISet<string> conjunctionFiltered = new HashSet<string>(_invertedIndexContextWrapper.GetDocumentsContainQuery(firstQuery));

            return signQueries.Aggregate(conjunctionFiltered, (current, query) =>
                current.Intersect(_invertedIndexContextWrapper.GetDocumentsContainQuery(query)).
                    ToHashSet());
        }
    }
}