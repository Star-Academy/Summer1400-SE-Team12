using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Phase05
{
    public class FileReader : IFileReader
    {
        public Dictionary<string, string> ReadFile(string path)
        {
            var documents = new Dictionary<string, string>();
            try
            {
                Directory.GetFiles(path).ToDictionary(Path.GetFileName,
                    File.ReadAllText);
            }
            catch (FileNotFoundException filException)
            {
                Console.WriteLine(filException);
                Environment.Exit(1);
            }

            return documents;
        }
    }
}