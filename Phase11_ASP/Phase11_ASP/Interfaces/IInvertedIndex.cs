using System.Collections.Generic;

namespace Phase11_ASP.Interfaces
{
    internal interface IInvertedIndex
    {
        void BuildInvertedIndex(IDictionary<string, string> documents);
    }
}