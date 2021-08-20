using System.Collections.Generic;

namespace Phase11_ASP.Interfaces
{
    public interface ISearchEngine
    {
        ISet<string> Search(string[] queries, string folderPath);
    }
}