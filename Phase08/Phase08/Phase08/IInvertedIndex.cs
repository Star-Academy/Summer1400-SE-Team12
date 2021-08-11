using System.Collections.Generic;

namespace Phase08
{
    public interface IInvertedIndex
    {
        void BuildInvertedIndex(ISet<Document> documents);
    }
}