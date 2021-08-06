namespace Phase05
{
    public class SearchEngine
    {
        private readonly IFileReader _fileReader;
        private readonly IIOHandler _ioHandler;
        private readonly IQueryCategorizer _queryCategorizer;
        private readonly IInvertedIndex _invertedIndex;
        private readonly IFilterHandler _filterHandler;

        public SearchEngine(IFileReader fileReader, IIOHandler ioHandler, IQueryCategorizer queryCategorizer, IInvertedIndex invertedIndex, IFilterHandler filterHandler)
        {
            _fileReader = fileReader;
            _ioHandler = ioHandler;
            _queryCategorizer = queryCategorizer;
            _invertedIndex = invertedIndex;
            _filterHandler = filterHandler;
        }

        public void Search(string filePath)
        {
            var documents = _fileReader.ReadFile(filePath);
            var queries = _ioHandler.ReadQueries();
            _invertedIndex.BuildInvertedIndex(documents);
            var queryKeeper = _queryCategorizer.CategorizeQueries(queries);
            var answers = _filterHandler.Filter(queryKeeper);
            _ioHandler.PrintResultDocuments(answers);
        }
    }
}