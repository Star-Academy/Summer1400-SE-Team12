using System.Collections.Generic;

namespace Phase11_ASP.Interfaces
{
    internal interface IFilter
    {
        ISet<string> Filter(ISet<string> signQueries);
    }
}