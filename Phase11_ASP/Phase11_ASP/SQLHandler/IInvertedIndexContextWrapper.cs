using System.Collections.Generic;
using Phase11_ASP.Models;

namespace Phase11_ASP.SQLHandler
{
    public interface IInvertedIndexContextWrapper
    {
        IEnumerable<string> GetDocumentsContainQuery(string query);
        bool IsDataBaseInitialized();
        void AddDocumentWords(Document document, IEnumerable<string> docWords);
        
    }
}