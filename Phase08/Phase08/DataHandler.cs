using Castle.Core.Internal;
using SQLHandler;

namespace Phase08
{
    public class DataHandler : IDataHandler
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
            
            var documents = _fileReader.ReadFile(folderPath);
            _invertedIndex.BuildInvertedIndex(documents);
        }
        
    }
}