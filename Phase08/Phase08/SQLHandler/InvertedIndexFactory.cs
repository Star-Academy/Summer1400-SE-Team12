using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SQLHandler
{
    public class InvertedIndexFactory : IDesignTimeDbContextFactory<InvertedIndexContext>
    {
        public InvertedIndexContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<InvertedIndexContext>();
            builder.UseSqlServer("Server=. ; Database=EfcorePhase08Project ; Trusted_Connection=true; ");
            return new InvertedIndexContext(builder.Options);
        }
        
    }
}