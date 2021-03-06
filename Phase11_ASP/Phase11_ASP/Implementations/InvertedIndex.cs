using System.Collections.Generic;
using System.Text.RegularExpressions;
using Phase11_ASP.Interfaces;
using Phase11_ASP.Models;
using Phase11_ASP.SQLHandler;

namespace Phase11_ASP.Implementations
{
    internal class InvertedIndex : IInvertedIndex
    {
        private readonly IInvertedIndexContextWrapper _invertedIndexContextWrapper;

        public InvertedIndex(IInvertedIndexContextWrapper invertedIndexContextWrapper)
        {
            _invertedIndexContextWrapper = invertedIndexContextWrapper;
        }

        public void BuildInvertedIndex(IDictionary<string, string> docMapToContent)
        {
            foreach (var (docName, docContent) in docMapToContent)
            {
                var words = SplitDocumentsWords(docContent);
                var document = new Document() {DocName = docName, DocContents = docContent};
                _invertedIndexContextWrapper.AddDocumentWords(document, words);
            }
        }

        private string[] SplitDocumentsWords(string docContent)
        {
            return Regex.Split(docContent, "[\\W]+");
        }

        
    }
}