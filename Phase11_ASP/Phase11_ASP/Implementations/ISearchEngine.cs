using System.Collections.Generic;

namespace Phase11_ASP.Implementations
{
    public interface ISearchEngine
    {
        ISet<string> Search(string[] queries, string folderPath);
    }
}