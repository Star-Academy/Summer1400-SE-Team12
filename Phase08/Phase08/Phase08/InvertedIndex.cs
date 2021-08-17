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
            foreach (var (docName, docContent) in docMapToContent)
            {
                var words = SplitDocumentsWords(docContent);
                var document = new Document(docName, docContent);
                AddDocumentWords(document, words);
            }
        }

        private string[] SplitDocumentsWords(string docContent)
        {
            return Regex.Split(docContent, "[\\W]+");
        }

        private void AddDocumentWords(Document document, IEnumerable<string> docWords)
        {
            foreach (var wordIterator in docWords)
            {
                var word = _invertedIndexContext.WordsDbContext.FirstOrDefault(w => w.Content == wordIterator);
                if (word == null)
                    AddNewWord(wordIterator);
                word.DocsCollection.Add(document);
            }
        }

        private void AddNewWord(string wordContent)
        {
            _invertedIndexContext.WordsDbContext.Add(new Word(wordContent, new List<Document>()));
            _invertedIndexContext.SaveChanges();
        }
    }
}