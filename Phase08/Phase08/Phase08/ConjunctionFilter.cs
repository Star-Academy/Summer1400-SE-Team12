using System.Collections.Generic;
using System.Linq;
using SQLHandler;

namespace Phase08
{
    public class ConjunctionFilter : IFilter
    {
        private readonly IInvertedIndexWrapper _invertedIndexWrapper;

        public ConjunctionFilter(IInvertedIndexWrapper invertedIndexWrapper)
        {
            _invertedIndexWrapper = invertedIndexWrapper;
        }

        public ISet<string> Filter(ISet<string> signQueries)
        {
            var firstQuery = signQueries.First();
            ISet<string> conjunctionFiltered = new HashSet<string>(_invertedIndexWrapper.GetDocumentsContainQuery(firstQuery));

            return signQueries.Aggregate(conjunctionFiltered, (current, query) =>
                current.Intersect(_invertedIndexWrapper.GetDocumentsContainQuery(query)).
                    ToHashSet());
        }
    }
}