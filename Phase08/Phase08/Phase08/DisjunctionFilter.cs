using System.Collections.Generic;
using System.Linq;
using SQLHandler;

namespace Phase08
{
    public class DisjunctionFilter : IFilter
    {
        private readonly IInvertedIndexWrapper _invertedIndexWrapper;

        public DisjunctionFilter(IInvertedIndexWrapper invertedIndexWrapper)
        {
            _invertedIndexWrapper = invertedIndexWrapper;
        }

        public ISet<string> Filter(ISet<string> signQueries)
        {
            var disjunctionFiltered = new HashSet<string>();
            
            return signQueries.Aggregate(disjunctionFiltered, (current, query) =>
                current.Union(_invertedIndexWrapper.GetDocumentsContainQuery(query)).
                    ToHashSet());
        }

        
    }
}