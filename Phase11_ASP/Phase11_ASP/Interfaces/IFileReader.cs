using System.Collections.Generic;

namespace Phase11_ASP.Interfaces
{
    public interface IFileReader
    {
        Dictionary<string,string> ReadFile(string path);
    }
}