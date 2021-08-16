using System.Collections.Generic;
using System.Linq;
using SQLHandler;

namespace Phase08
{
    public class ConjunctionFilter : IFilter
    {
        private readonly InvertedIndexContext _invertedIndexContext;

        public ConjunctionFilter(InvertedIndexContext invertedIndexContext)
        {
            _invertedIndexContext = invertedIndexContext;
        }

        public ISet<string> Filter(ISet<string> signQueries)
        {
            var firstQuery = signQueries.First();
            ISet<string> conjunctionFiltered = new HashSet<string>(_invertedIndexContext.GetDocumentsContainQuery(firstQuery));

            return signQueries.Aggregate(conjunctionFiltered, (current, query) =>
                current.Intersect(_invertedIndexContext.GetDocumentsContainQuery(query)).
                    ToHashSet());
        }
    }
}