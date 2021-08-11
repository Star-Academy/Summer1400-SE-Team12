using System.Collections.Generic;
using SQLHandler;

namespace Phase08
{
    public interface IInvertedIndex
    {
        void BuildInvertedIndex(ISet<Document> documents);
    }
}