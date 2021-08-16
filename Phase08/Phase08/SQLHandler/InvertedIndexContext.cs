using System;
using Microsoft.EntityFrameworkCore;

namespace SQLHandler
{
    public class InvertedIndexContext:DbContext, IDisposable
    {
        public DbSet<Word> WordsDbContext { get; set; }
        public DbSet<Document> DocumentsDbContext { get; set; }

        // public InvertedIndexContext()
        // { }
        //
        public InvertedIndexContext(DbContextOptions<InvertedIndexContext> options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().
                HasMany(docIterator => docIterator.wordsCollection).
                WithMany(wordIterator => wordIterator.DocsCollection);
        }
    }
}