using System.Collections.Generic;

namespace Phase05
{
    public interface IFilterHandler
    {
        ISet<string> Filter(QueryKeeper queryKeeper);
    }
}