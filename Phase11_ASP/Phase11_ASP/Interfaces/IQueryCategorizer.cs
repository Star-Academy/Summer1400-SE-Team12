using System.Collections.Generic;
using Phase11_ASP.Implementations;

namespace Phase11_ASP.Interfaces
{
    public interface IQueryCategorizer
    {
        QueryKeeper CategorizeQueries(string[] queries);
    }
    
}