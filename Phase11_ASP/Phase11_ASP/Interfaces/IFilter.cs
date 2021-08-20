using System.Collections.Generic;

namespace Phase11_ASP.Interfaces
{
    public interface IFilter
    {
        delegate IFilter ServiceResolver(string key);
        ISet<string> Filter(ISet<string> signQueries);
    }
}