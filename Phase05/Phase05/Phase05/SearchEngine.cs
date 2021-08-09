using System.Collections.Generic;

namespace Phase05
{
    public class SearchEngine
    {
        private readonly IIOHandler _ioHandler;
        private readonly IQueryCategorizer _queryCategorizer;
        private readonly IInvertedIndex _invertedIndex;
        private readonly IFilterHandler _filterHandler;

        public SearchEngine(IIOHandler ioHandler, IQueryCategorizer queryCategorizer, IInvertedIndex invertedIndex, IFilterHandler filterHandler)
        {
            _ioHandler = ioHandler;
            _queryCategorizer = queryCategorizer;
            _invertedIndex = invertedIndex;
            _filterHandler = filterHandler;
        }

        public ISet<string> Search(string folderPath)
        {
            var documents = _ioHandler.ReadDocuments(folderPath);
            var queries = _ioHandler.ReadQueries();
            _invertedIndex.BuildInvertedIndex(documents);
            var queryKeeper = _queryCategorizer.CategorizeQueries(queries);
            var answers = _filterHandler.Filter(queryKeeper);
            return answers;
        }
    }
}