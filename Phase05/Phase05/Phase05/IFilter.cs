using System.Collections.Generic;

namespace Phase05
{
    public interface IFilter
    {
        HashSet<string> Filter(HashSet<string> signQueries);
    }
}