using System.Collections.Generic;

namespace Phase05
{
    public interface IIOHandler
    {
        string[] ReadQueries();
        void PrintResultDocuments(ISet<string> answers);
    }
}
