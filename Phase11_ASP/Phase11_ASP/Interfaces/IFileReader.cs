using System.Collections.Generic;

namespace Phase11_ASP.Interfaces
{
    public interface IFileReader
    {
        IDictionary<string,string> ReadFile(string path);
    }
}