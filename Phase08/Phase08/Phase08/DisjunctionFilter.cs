using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SQLHandler;

namespace Phase08
{
    public class DisjunctionFilter : IFilter
    {
        private readonly InvertedIndexContext _invertedIndexContext;

        public DisjunctionFilter(InvertedIndexContext invertedIndexContext)
        {
            _invertedIndexContext = invertedIndexContext;
        }

        public ISet<string> Filter(ISet<string> signQueries)
        {
            var disjunctionFiltered = new HashSet<string>();
            
            return signQueries.Aggregate(disjunctionFiltered, (current, query) =>
                current.Union(_invertedIndexContext.GetDocumentsContainQuery(query)).
                    ToHashSet());
        }

        
    }
}