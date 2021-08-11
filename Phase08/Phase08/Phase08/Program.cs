using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Phase08
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\programming\codestar_internship\Phase08\Phase08\Phase08\EnglishData";
            using var invertedIndexContext = new InvertedIndexContext();
            if(!(invertedIndexContext.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                invertedIndexContext.Database.EnsureCreated();
            
            var fileReader = new FileReader(invertedIndexContext.DocumentsDbContext);
            var ioHandler = new IOHandler();
            var queryCategorizer = new QueryCategorizer();
            var invertedIndex = new InvertedIndex(invertedIndexContext);
            var conjunctionFilter = new ConjunctionFilter(invertedIndexContext.WordsDbContext);
            var disjunctionFilter = new DisjunctionFilter(invertedIndexContext.WordsDbContext);
            var filterHandler = new FilterHandler(conjunctionFilter, disjunctionFilter);
            
            var searchEngine = new SearchEngine(fileReader,ioHandler,queryCategorizer, 
                invertedIndex, filterHandler,invertedIndexContext);
            var answers = searchEngine.Search(path);
            ioHandler.PrintResultDocuments(answers);
            
        }
    }
}
