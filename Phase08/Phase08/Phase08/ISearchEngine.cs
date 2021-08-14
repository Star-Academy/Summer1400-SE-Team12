using System.Collections.Generic;

namespace Phase08
{
    public interface ISearchEngine
    {
        ISet<string> Search();
    }
}