using System.Collections.Generic;

namespace Phase11_ASP.Interfaces
{
    public interface IFilter
    {
        ISet<string> Filter(ISet<string> signQueries);
    }
}