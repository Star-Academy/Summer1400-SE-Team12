using System.Collections.Generic;

namespace Phase11_ASP.Interfaces
{
    public interface ISearchEngine
    {
        ISet<string> Search(IEnumerable<string> queries, string folderPath);
    }
}