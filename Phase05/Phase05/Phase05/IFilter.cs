using System.Collections.Generic;

namespace Phase05
{
    public interface IFilter : IInvertedIndex
    {
        HashSet<string> Filter(HashSet<string> signQueries);
    }
}