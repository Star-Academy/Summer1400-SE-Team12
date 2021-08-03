using System.Collections.Generic;

namespace Phase05
{
    public interface IInvertedIndex
    {
        HashSet<string> getInvertedIndexValue(string key);
    }
}