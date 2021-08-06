
namespace Phase05
{
    class Program
    {
        private const string FilePath = "D:\\programming\\java\\code-star\\src\\EnglishData";

        public static void Main(string[] args)
        {
            var fileReader = new FileReader();
            var documents = fileReader.ReadFile(FilePath);
            var IOHandler = new IOHandler();
            var queries = IOHandler.ReadQueries();
            var queryKeeper = new QueryCategorizer().CategorizeQueries(queries);
            var invertedIndex = new InvertedIndex();
            invertedIndex.BuildInvertedIndex(documents);
            var conjunctionFilter = new ConjunctionFilter(invertedIndex);
            var disjunctionFilter = new DisjunctionFilter(invertedIndex);
            var filterHandler = new FilterHandler(conjunctionFilter, disjunctionFilter);
            var answers = filterHandler.Filter(queryKeeper);
            IOHandler.PrintResultDocuments(answers);
            
        }
    }
}