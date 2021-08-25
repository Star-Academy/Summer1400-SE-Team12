using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Phase11_ASP.Models;

namespace Phase11_ASP.SQLHandler
{
    public class InvertedIndexContext : DbContext
    {
        public DbSet<Word> WordsDbContext { get; set; }
        public DbSet<Document> DocumentsDbContext { get; set; }

        public InvertedIndexContext(DbContextOptions<InvertedIndexContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().HasMany(docIterator => docIterator.wordsCollection)
                .WithMany(wordIterator => wordIterator.DocsCollection);
        }
        
    }
}