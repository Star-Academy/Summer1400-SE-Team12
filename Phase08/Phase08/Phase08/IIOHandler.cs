using System.Collections.Generic;

namespace Phase08
{
    public interface IIOHandler
    {
        void ReadDocuments(string path);
        string[] ReadQueries();
        void PrintResultDocuments(ISet<string> answers);
    }
}