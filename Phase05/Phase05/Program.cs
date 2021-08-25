
namespace Phase05
{
    class Program
    {
        private const string FilePath = @"EnglishData";

        public static void Main(string[] args)
        {
            var fileReader = new FileReader();
            var ioHandler = new IOHandler();
            var queryCategorizer = new QueryCategorizer();
            var invertedIndex = new InvertedIndex();
            var conjunctionFilter = new ConjunctionFilter(invertedIndex);
            var disjunctionFilter = new DisjunctionFilter(invertedIndex);
            var filterHandler = new FilterHandler(conjunctionFilter, disjunctionFilter);
            
            var searchEngine = new SearchEngine(ioHandler,fileReader,queryCategorizer,invertedIndex,filterHandler);
            var answers = searchEngine.Search(FilePath);
            ioHandler.PrintResultDocuments(answers);
        }
    }
}