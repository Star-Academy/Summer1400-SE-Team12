using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Phase11_ASP.Interfaces;

namespace Phase11_ASP.Implementations
{
    public class FileReader : IFileReader
    {
        public IDictionary<string, string> ReadFile(string path)
        {
            var documents = new Dictionary<string, string>();
            try
            {
                documents = Directory.GetFiles(path).ToDictionary(Path.GetFileName, File.ReadAllText);
            }
            catch (Exception filException)
            {
                Console.WriteLine(filException);
                Environment.Exit(1);
            }

            return documents;
        }
    }
}