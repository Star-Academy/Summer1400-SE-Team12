using System.Collections.Generic;
using System.Linq;
using Phase11_ASP.Interfaces;
using Phase11_ASP.SQLHandler;

namespace Phase11_ASP.Implementations
{
    internal class DisjunctionFilter : IFilter
    {
        private readonly IInvertedIndexContextWrapper _invertedIndexContextWrapper;
        
        public DisjunctionFilter(IInvertedIndexContextWrapper invertedIndexContextWrapper)
        {
            _invertedIndexContextWrapper = invertedIndexContextWrapper;
            
        }

        public ISet<string> Filter(ISet<string> signQueries)
        {
            var disjunctionFiltered = new HashSet<string>();
            
            var filteredDocs =  signQueries.Aggregate(disjunctionFiltered, (current, query) =>
                current.Union(_invertedIndexContextWrapper.GetDocumentsContainQuery(query)).
                    ToHashSet());
            return filteredDocs;
        }

        
    }
}