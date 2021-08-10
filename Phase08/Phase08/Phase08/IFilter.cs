using System.Collections.Generic;

namespace Phase08
{
    public interface IFilter
    {
        ISet<string> Filter(ISet<string> signQueries);
    }
}