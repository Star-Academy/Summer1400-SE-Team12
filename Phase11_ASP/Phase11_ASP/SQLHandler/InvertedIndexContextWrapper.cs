using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            var word = _invertedIndexContext.WordsDbContext.Include(x => x.DocsCollection).FirstOrDefault(x => x.Content == query);
            return word == null ? new List<string>() : word.DocsCollection.Select(doc => doc.DocName);
        }

        public bool IsDataBaseInitialized()
        {
            var isAnyDoc = _invertedIndexContext.DocumentsDbContext.Any();
            var isAnyWord = _invertedIndexContext.WordsDbContext.Any();
            return isAnyDoc && isAnyWord;
        }

        public void AddDocumentWords(Document document, IEnumerable<string> docWords)
        {
            foreach (var wordIterator in docWords)
            {
                var word = _invertedIndexContext.WordsDbContext.FirstOrDefault(w => w.Content == wordIterator);
                if (word == null)
                {
                    _invertedIndexContext.WordsDbContext.Add(new Word()
                        {Content = wordIterator, DocsCollection = new List<Document>() {document}});
                    _invertedIndexContext.SaveChanges();
                }
                else
                {
                    word.DocsCollection.Add(document);
                }
            }
        }
        
    }
}