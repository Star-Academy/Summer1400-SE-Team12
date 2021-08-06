
namespace Phase05
{
    class Program
    {
        private const string FilePath = "D:\\programming\\java\\code-star\\src\\EnglishData";

        public static void Main(string[] args)
        {
            var fileReader = new FileReader();
            var ioHandler = new IOHandler(fileReader);
            var queryCategorizer = new QueryCategorizer();
            var invertedIndex = new InvertedIndex();
            var conjunctionFilter = new ConjunctionFilter(invertedIndex);
            var disjunctionFilter = new DisjunctionFilter(invertedIndex);
            var filterHandler = new FilterHandler(conjunctionFilter, disjunctionFilter);
            
            var searchEngine = new SearchEngine(ioHandler,queryCategorizer,invertedIndex,filterHandler);
            searchEngine.Search(FilePath);
        }
    }
}