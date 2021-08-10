using System.Collections.Generic;

namespace Phase08
{
    public interface IFileReader
    {
        Dictionary<string, string> ReadFile(string path);
    }
}