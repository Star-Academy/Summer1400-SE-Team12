using SQLHandler;

namespace Phase08
{
    class Program
    {
        const string path = @"D:\programming\codestar_internship\Phase08\Phase08\Phase08\EnglishData";
        static void Main(string[] args)
        {
            var invertedIndexContext = new InvertedIndexFactory().CreateDbContext(args);
            var fileReader = new FileReader();
            var ioHandler = new IOHandler();
            var queryCategorizer = new QueryCategorizer();
            var invertedIndex = new InvertedIndex(invertedIndexContext);
            var conjunctionFilter = new ConjunctionFilter(invertedIndexContext.WordsDbContext);
            var disjunctionFilter = new DisjunctionFilter(invertedIndexContext.WordsDbContext);
            var filterHandler = new FilterHandler(conjunctionFilter, disjunctionFilter);
            
            var searchEngine = new SearchEngine(ioHandler,queryCategorizer, filterHandler);
            var dataHandler = new DataHandler(fileReader, invertedIndex, invertedIndexContext);
            var connectorDataAndSearchEngine = new ConnectorDataAndSearchEngine(searchEngine, dataHandler);
            var answers = connectorDataAndSearchEngine.Connect(path);
            ioHandler.PrintResultDocuments(answers);
            
        }
    }
}
