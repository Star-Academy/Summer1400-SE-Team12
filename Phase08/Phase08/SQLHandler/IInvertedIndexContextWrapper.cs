using System.Collections.Generic;

namespace SQLHandler
{
    public interface IInvertedIndexContextWrapper
    {
        IEnumerable<string> GetDocumentsContainQuery(string query);
        bool IsDataBaseInitialized();
        void AddDocumentWords(Document document, IEnumerable<string> docWords);
        
    }
}