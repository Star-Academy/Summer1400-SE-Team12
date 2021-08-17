using System.Collections.Generic;

namespace Phase08
{
    public interface IConnectorDataAndSearchEngine
    {
        ISet<string> Connect(string folderPath);
    }
}