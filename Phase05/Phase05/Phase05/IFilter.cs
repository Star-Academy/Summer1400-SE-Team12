using System.Collections.Generic;

namespace Phase05
{
    public interface IFilter
    {
        ISet<string> Filter(ISet<string> signQueries);
    }
}