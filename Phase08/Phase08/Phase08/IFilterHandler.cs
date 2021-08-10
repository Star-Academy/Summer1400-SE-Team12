using System.Collections.Generic;

namespace Phase08
{
    public interface IFilterHandler
    {
        ISet<string> Filter(IQueryKeeper queryKeeper);
    }
}