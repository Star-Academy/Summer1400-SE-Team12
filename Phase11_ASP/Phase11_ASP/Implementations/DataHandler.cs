using Phase11_ASP.Interfaces;
using Phase11_ASP.SQLHandler;

namespace Phase11_ASP.Implementations
{
    internal class DataHandler : IDataHandler
    {
        private readonly IFileReader _fileReader;
        private readonly IInvertedIndex _invertedIndex;
        private readonly IInvertedIndexContextWrapper _invertedIndexContextWrapper;

        public DataHandler(IFileReader fileReader, IInvertedIndex invertedIndex,
            IInvertedIndexContextWrapper invertedIndexContextWrapper)
        {
            _fileReader = fileReader;
            _invertedIndex = invertedIndex;
            _invertedIndexContextWrapper = invertedIndexContextWrapper;
        }

        public void InitializeDataBase(string folderPath)
        {
            if (_invertedIndexContextWrapper.IsDataBaseInitialized()) return;
            
            var documents = _fileReader.ReadFiles(folderPath);
            _invertedIndex.BuildInvertedIndex(documents);
        }
        
    }
}