using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SQLHandler
{
    public class InvertedIndexContext : DbContext
    {
        public DbSet<Word> WordsDbContext { get; set; }
        public DbSet<Document> DocumentsDbContext { get; set; }
        
        public InvertedIndexContext(DbContextOptions<InvertedIndexContext> options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().
                HasMany(docIterator => docIterator.wordsCollection).
                WithMany(wordIterator => wordIterator.DocsCollection);
        }
        
        public IEnumerable<string> GetDocumentsContainQuery(string query)
        {
            var word = WordsDbContext.Include(x => x.DocsCollection).
                FirstOrDefault(x => x.Content == query);
            return word == null ? new List<string>() : word.DocsCollection.Select(doc => doc.DocName);
        }
        
        public bool IsDataBaseInitialized()
        {
            return !DocumentsDbContext.Any() &&
                   !WordsDbContext.Any();
        }
        
        public void AddDocumentWords(Document document, IEnumerable<string> docWords)
        {
            foreach (var wordIterator in docWords)
            {
                var word = WordsDbContext.FirstOrDefault(w => w.Content == wordIterator);
                if (word == null)
                    WordsDbContext.Add(new Word(){Content = wordIterator, DocsCollection = new List<Document>()});
                word.DocsCollection.Add(document);
            }
        }
        
    }
}