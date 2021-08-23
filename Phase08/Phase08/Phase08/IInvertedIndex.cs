using System.Collections.Generic;
using SQLHandler;

namespace Phase08
{
    public interface IInvertedIndex
    {
        void BuildInvertedIndex(Dictionary<string, string> documents);
    }
}