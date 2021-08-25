using System.Collections.Generic;

namespace Phase08
{
    public interface ISearchEngine
    {
        ISet<string> Search(string[] queries, string folderPath);
    }
}