using System.Collections.Generic;

namespace Phase08
{
    public interface IIOHandler
    {
        string[] ReadQueries();
        void PrintResultDocuments(ISet<string> answers);
    }
}