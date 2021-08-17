using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SQLHandler;

namespace Phase08
{
    public class InvertedIndex : IInvertedIndex
    {
        private readonly IInvertedIndexContextWrapper _invertedIndexContextWrapper;

        public InvertedIndex(IInvertedIndexContextWrapper invertedIndexContextWrapper)
        {
            _invertedIndexContextWrapper = invertedIndexContextWrapper;
        }

        public void BuildInvertedIndex(Dictionary<string, string> docMapToContent)
        {
            foreach (var (docName, docContent) in docMapToContent)
            {
                var words = SplitDocumentsWords(docContent);
                var document = new Document(docName, docContent);
                _invertedIndexContextWrapper.AddDocumentWords(document, words);
            }
        }

        private string[] SplitDocumentsWords(string docContent)
        {
            return Regex.Split(docContent, "[\\W]+");
        }

        
    }
}