using System.Collections.Generic;

namespace Phase08
{
    public class SearchEngine : ISearchEngine
    {
        private readonly IQueryCategorizer _queryCategorizer;
        private readonly IFilterHandler _filterHandler;
        private readonly IDataHandler _dataHandler;
        

        public SearchEngine( IQueryCategorizer queryCategorizer,
             IFilterHandler filterHandler, IDataHandler dataHandler)
        {
            _queryCategorizer = queryCategorizer;
            _filterHandler = filterHandler;
            _dataHandler = dataHandler;
        }

        public ISet<string> Search(IEnumerable<string> queries,string folderPath)
        {
            _dataHandler.InitializeDataBase(folderPath);
            var queryKeeper = _queryCategorizer.CategorizeQueries(queries);
            var answers = _filterHandler.Filter(queryKeeper);
            return answers;
        }
    }
}