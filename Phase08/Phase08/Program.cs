using System;
using SQLHandler;

namespace Phase08
{
    class Program
    {
        const string path = @"D:\programming\Summer1400-SE-Team12\Phase08\Phase08\Phase08\EnglishData";
        static void Main(string[] args)
        {
            var invertedIndexContext = new InvertedIndexFactory().CreateDbContext(args);
            var invertedIndexWrapper = new InvertedIndexContextWrapper(invertedIndexContext);
            var fileReader = new FileReader();
            var ioHandler = new IOHandler();
            var queryCategorizer = new QueryCategorizer();
            var invertedIndex = new InvertedIndex(invertedIndexWrapper);
            var conjunctionFilter = new ConjunctionFilter(invertedIndexWrapper);
            var disjunctionFilter = new DisjunctionFilter(invertedIndexWrapper);
            var filterHandler = new FilterHandler(conjunctionFilter, disjunctionFilter);
            
            var dataHandler = new DataHandler(fileReader, invertedIndex, invertedIndexWrapper);
            var searchEngine = new SearchEngine(queryCategorizer, filterHandler, dataHandler);
            
            var queries = ioHandler.ReadQueries();
            var answers = searchEngine.Search(queries,path);
            ioHandler.PrintResultDocuments(answers);
            
        }
    }
}
