using System.Collections.Generic;

namespace Phase08
{
    public interface IQueryCategorizer
    {
        QueryKeeper CategorizeQueries(IEnumerable<string> queries);
    }
    
}