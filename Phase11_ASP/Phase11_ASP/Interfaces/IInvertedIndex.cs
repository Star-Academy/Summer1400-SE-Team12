using System.Collections.Generic;

namespace Phase11_ASP.Interfaces
{
    public interface IInvertedIndex
    {
        void BuildInvertedIndex(IDictionary<string, string> documents);
    }
}