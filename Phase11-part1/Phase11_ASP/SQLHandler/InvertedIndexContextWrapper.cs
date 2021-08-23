using System.Collections.Generic;
using Phase11_ASP.Models;

namespace Phase11_ASP.SQLHandler
{
    public class InvertedIndexContextWrapper : IInvertedIndexContextWrapper
    {
        private InvertedIndexContext _invertedIndexContext;

        public InvertedIndexContextWrapper(InvertedIndexContext invertedIndexContext)
        {
            _invertedIndexContext = invertedIndexContext;
        }

        public IEnumerable<string> GetDocumentsContainQuery(string query)
        {
            return _invertedIndexContext.GetDocumentsContainQuery(query);
        }

        public bool IsDataBaseInitialized()
        {
            return _invertedIndexContext.IsDataBaseInitialized();
        }

        public void AddDocumentWords(Document document, IEnumerable<string> docWords)
        {
            _invertedIndexContext.AddDocumentWords(document,docWords);
        }
        
    }
}