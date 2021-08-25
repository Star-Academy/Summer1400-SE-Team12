using System.Collections.Generic;
using Phase11_ASP.Implementations;

namespace Phase11_ASP.Interfaces
{
    internal interface IQueryCategorizer
    {
        QueryKeeper CategorizeQueries(IEnumerable<string> queries);
    }
    
}