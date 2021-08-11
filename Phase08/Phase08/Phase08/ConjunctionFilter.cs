using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SQLHandler;

namespace Phase08
{
    public class ConjunctionFilter : IFilter
    {
        private readonly DbSet<Word> _wordDBSet;

        public ConjunctionFilter(DbSet<Word> wordDbSet)
        {
            _wordDBSet = wordDbSet;
        }

        public ISet<string> Filter(ISet<string> signQueries)
        {
            var firstQuery = signQueries.First();
            ISet<string> conjunctionFiltered = new HashSet<string>(
                _wordDBSet.Find(firstQuery)?.
                    DocsCollection.
                    Select(doc => doc.DocName) ?? new HashSet<string>());

            return signQueries.Aggregate(conjunctionFiltered, (current, query) =>
                current.Intersect(_wordDBSet.Find(query)?.
                                      DocsCollection.
                                      Select(doc => doc.DocName) ?? new HashSet<string>()).
                    ToHashSet());
        }
    }
}