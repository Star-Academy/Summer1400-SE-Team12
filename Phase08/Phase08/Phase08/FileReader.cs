using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Phase08
{
    public class FileReader : IFileReader
    {
        public Dictionary<string, string> ReadFile(string path)
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