using System.Collections.Generic;

namespace Phase11_ASP.Interfaces
{
    public interface IInvertedIndex
    {
        void BuildInvertedIndex(Dictionary<string, string> documents);
    }
}