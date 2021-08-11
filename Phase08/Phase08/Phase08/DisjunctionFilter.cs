using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Phase08
{
    public class DisjunctionFilter : IFilter
    {
        private readonly DbSet<Word> _wordDBSet;

        public DisjunctionFilter(DbSet<Word> wordDbSet)
        {
            _wordDBSet = wordDbSet;
        }

        public ISet<string> Filter(ISet<string> signQueries)
        {
            var disjunctionFiltered = new HashSet<string>();
            
            return signQueries.Aggregate(disjunctionFiltered, (current, query) =>
                current.Union(_wordDBSet.Find(query)?.
                                  DocsCollection.
                                  Select(doc => doc.DocName) ?? new HashSet<string>()).
                    ToHashSet());
        }
    }
}