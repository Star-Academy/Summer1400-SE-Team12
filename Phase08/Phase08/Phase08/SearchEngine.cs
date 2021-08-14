using System.Collections.Generic;

namespace Phase08
{
    public class SearchEngine : ISearchEngine
    {
        private readonly IIOHandler _ioHandler;
        private readonly IQueryCategorizer _queryCategorizer;
        private readonly IFilterHandler _filterHandler;
        

        public SearchEngine(IIOHandler ioHandler, IQueryCategorizer queryCategorizer,
             IFilterHandler filterHandler)
        {
            _ioHandler = ioHandler;
            _queryCategorizer = queryCategorizer;
            _filterHandler = filterHandler;
        }

        public ISet<string> Search()
        {
            var queries = _ioHandler.ReadQueries();
            var queryKeeper = _queryCategorizer.CategorizeQueries(queries);
            var answers = _filterHandler.Filter(queryKeeper);
            return answers;
        }
    }
}