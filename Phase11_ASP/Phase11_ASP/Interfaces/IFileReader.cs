using System.Collections.Generic;

namespace Phase11_ASP.Interfaces
{
    internal interface IFileReader
    {
        IDictionary<string,string> ReadFiles(string path);
    }
}