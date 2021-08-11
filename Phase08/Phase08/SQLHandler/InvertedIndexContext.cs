
using Microsoft.EntityFrameworkCore;

namespace SQLHandler
{
    public class InvertedIndexContext:DbContext
    {
        public DbSet<Word> WordsDbContext { get; set; }
        public DbSet<Document> DocumentsDbContext { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=. ; Database=EfcorePhase08Project ; Trusted_Connection=true; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Document>().HasMany(docIterator => docIterator.wordsCollection).WithMany(wordIterator => wordIterator.DocsCollection);
        
        }
    }
}