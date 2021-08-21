using System.Collections.Generic;
using Phase11_ASP.Interfaces;

namespace Phase11_ASP.Implementations
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