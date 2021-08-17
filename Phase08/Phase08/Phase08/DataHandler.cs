using Castle.Core.Internal;
using SQLHandler;

namespace Phase08
{
    public class DataHandler : IDataHandler
    {
        private readonly IFileReader _fileReader;
        private readonly IInvertedIndex _invertedIndex;
        private readonly IInvertedIndexWrapper _invertedIndexWrapper;

        public DataHandler(IFileReader fileReader, IInvertedIndex invertedIndex,
            IInvertedIndexWrapper invertedIndexWrapper)
        {
            _fileReader = fileReader;
            _invertedIndex = invertedIndex;
            _invertedIndexWrapper = invertedIndexWrapper;
        }

        public void InitializeDataBase(string folderPath)
        {
            if (_invertedIndexWrapper.IsDataBaseInitialized()) return;
            
            var documents = _fileReader.ReadFile(folderPath);
            _invertedIndex.BuildInvertedIndex(documents);
        }
        
    }
}