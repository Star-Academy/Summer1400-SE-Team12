using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            ISet<string> conjunctionFiltered = new HashSet<string>(
                _invertedIndexContext.WordsDbContext.Include(x => x.DocsCollection).
                    FirstOrDefault( w => w.Content == firstQuery).DocsCollection.Select(doc => doc.DocName) ?? new HashSet<string>());

            return signQueries.Aggregate(conjunctionFiltered, (current, query) =>
                current.Intersect(_invertedIndexContext.WordsDbContext.Include(x => x.DocsCollection).
                    FirstOrDefault( w => w.Content == firstQuery).DocsCollection.Select(doc => doc.DocName) 
                 ?? new HashSet<string>()).
                    ToHashSet());
        }
    }
}