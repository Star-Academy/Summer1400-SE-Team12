using System.Collections.Generic;

namespace Phase05
{
    public interface ISearchEngine
    {
        ISet<string> Search(string folderPath);
    }
}