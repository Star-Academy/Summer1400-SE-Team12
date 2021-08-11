using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SQLHandler;

namespace Phase08
{
    public class SearchEngine
    {
        private readonly IFileReader _fileReader;
        private readonly IIOHandler _ioHandler;
        private readonly IQueryCategorizer _queryCategorizer;
        private readonly IInvertedIndex _invertedIndex;
        private readonly IFilterHandler _filterHandler;
        private readonly InvertedIndexContext _invertedIndexContext;

        public SearchEngine(IFileReader fileReader, IIOHandler ioHandler, IQueryCategorizer queryCategorizer, 
            IInvertedIndex invertedIndex, IFilterHandler filterHandler, InvertedIndexContext invertedIndexContext)
        {
            _fileReader = fileReader;
            _ioHandler = ioHandler;
            _queryCategorizer = queryCategorizer;
            _invertedIndex = invertedIndex;
            _filterHandler = filterHandler;
            _invertedIndexContext = invertedIndexContext;
        }

        public ISet<string> Search(string folderPath)
        {
            _fileReader.ReadFile(folderPath);
            _invertedIndexContext.SaveChanges();
            var queries = _ioHandler.ReadQueries();
            var documents = new HashSet<Document>(_invertedIndexContext.DocumentsDbContext);
            _invertedIndex.BuildInvertedIndex(documents);
            var queryKeeper = _queryCategorizer.CategorizeQueries(queries);
            var answers = _filterHandler.Filter(queryKeeper);
            return answers;
        }
    }
}