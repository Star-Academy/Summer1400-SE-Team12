using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SQLHandler;

namespace Phase08
{
    public class InvertedIndex : IInvertedIndex
    {
        private readonly InvertedIndexContext _invertedIndexContext;

        public InvertedIndex(InvertedIndexContext invertedIndexContext)
        {
            _invertedIndexContext = invertedIndexContext;
        }
        
        public void BuildInvertedIndex(Dictionary<string, string> docMapToContent)
        {
            foreach (var doc in docMapToContent)
            {
                var words = SplitDocumentsWords(doc.Value);
                var document = new Document(doc.Key, doc.Value);
                AddDocumentWords(document, words);
            }
        }

        private string[] SplitDocumentsWords(string docContent)
        {
            return Regex.Split(docContent, "[\\W]+");
        }

        private void AddDocumentWords(Document document, string[] docWords)
        {
            foreach (var wordIterator in docWords)
            {
                var word = _invertedIndexContext.WordsDbContext.FirstOrDefault(w => w.Content == wordIterator);
                if (word == null)
                {
                    _invertedIndexContext.WordsDbContext.Add(new Word(wordIterator, new List<Document>() {document}));
                    _invertedIndexContext.SaveChanges();
                }
                else
                    word.DocsCollection.Add(document);
            }
        }
        
    }
}