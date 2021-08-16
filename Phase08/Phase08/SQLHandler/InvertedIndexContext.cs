using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SQLHandler
{
    public class InvertedIndexContext:DbContext
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
            if (word == null)
                return new List<string>();
            return word.DocsCollection.Select(doc => doc.DocName) ;
        }
    }
}