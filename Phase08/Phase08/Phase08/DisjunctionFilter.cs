using System.Collections.Generic;
using System.Linq;
using SQLHandler;

namespace Phase08
{
    public class DisjunctionFilter : IFilter
    {
        private readonly IInvertedIndexContextWrapper _invertedIndexContextWrapper;

        public DisjunctionFilter(IInvertedIndexContextWrapper invertedIndexContextWrapper)
        {
            _invertedIndexContextWrapper = invertedIndexContextWrapper;
        }

        public ISet<string> Filter(ISet<string> signQueries)
        {
            var disjunctionFiltered = new HashSet<string>();
            
            return signQueries.Aggregate(disjunctionFiltered, (current, query) =>
                current.Union(_invertedIndexContextWrapper.GetDocumentsContainQuery(query)).
                    ToHashSet());
        }

        
    }
}