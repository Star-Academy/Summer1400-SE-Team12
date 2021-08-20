using System.Collections.Generic;

namespace Phase11_ASP.Implementations
{
    public interface IQueryCategorizer
    {
        QueryKeeper CategorizeQueries(IEnumerable<string> queries);
    }
    
}