using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SQLHandler;

namespace Phase08
{
    public class ConjunctionFilter : IFilter
    {
        private readonly DbSet<Word> _wordDbSet;

        public ConjunctionFilter(DbSet<Word> wordDbSet)
        {
            _wordDbSet = wordDbSet;
        }

        public ISet<string> Filter(ISet<string> signQueries)
        {
            var firstQuery = signQueries.First();
            ISet<string> conjunctionFiltered = new HashSet<string>(
                _wordDbSet.Find(firstQuery)?.
                    DocsCollection.
                    Select(doc => doc.DocName) ?? new HashSet<string>());

            return signQueries.Aggregate(conjunctionFiltered, (current, query) =>
                current.Intersect(_wordDbSet.Find(query)?.
                                      DocsCollection.
                                      Select(doc => doc.DocName) ?? new HashSet<string>()).
                    ToHashSet());
        }
    }
}