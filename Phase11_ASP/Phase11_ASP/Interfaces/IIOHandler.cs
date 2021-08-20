using System.Collections.Generic;

namespace Phase11_ASP.Interfaces
{
    public interface IIOHandler
    {
        string[] ReadQueries();
        void PrintResultDocuments(ISet<string> answers);
    }
}