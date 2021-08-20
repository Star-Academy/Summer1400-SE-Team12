using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Phase11_ASP.SQLHandler
{
    public class InvertedIndexFactory : IDesignTimeDbContextFactory<InvertedIndexContext>
    {
        public InvertedIndexContext CreateDbContext(string[] args)
        {
            const string connectionString =
                "Server=. ; Database=EfcorePhase08Project ; Trusted_Connection=true; MultipleActiveResultSets=true;";
            var builder = new DbContextOptionsBuilder<InvertedIndexContext>();
            builder.UseSqlServer(connectionString);
            return new InvertedIndexContext(builder.Options);
        }
        
    }
}