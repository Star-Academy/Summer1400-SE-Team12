using System.Collections.Generic;

namespace Phase05
{
    public interface IFilterHandler
    {
        HashSet<string> Filter();
    }
}