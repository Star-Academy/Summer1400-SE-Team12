using System.Collections.Generic;

namespace Phase05
{
    public interface IFileReader
    {
        Dictionary<string, string> ReadFile(string path);
    }
}