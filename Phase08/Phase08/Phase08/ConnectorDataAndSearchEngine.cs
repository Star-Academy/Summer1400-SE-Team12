using System.Collections.Generic;

namespace Phase08
{
    public class ConnectorDataAndSearchEngine : IConnectorDataAndSearchEngine
    {
        private readonly ISearchEngine _searchEngine;
        private readonly IDataHandler _dataHandler;

        public ConnectorDataAndSearchEngine(ISearchEngine searchEngine, IDataHandler dataHandler)
        {
            _searchEngine = searchEngine;
            _dataHandler = dataHandler;
        }

        public ISet<string> Connect(string folderPath)
        {
            _dataHandler.InitializeDataBase(folderPath);
            var answers = _searchEngine.Search();
            return answers;
        }
    }
}