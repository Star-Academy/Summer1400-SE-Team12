using System;
using System.Collections.Generic;
using System.IO;

namespace Phase05
{
    public class FileReader : IFileReader
    {
        public Dictionary<string, string> ReadFile(string path)
        {
            var documents = new Dictionary<string, string>();
            try
            {
                foreach (string filePath in Directory.GetFiles(path))
                    documents.Add(Path.GetFileName(filePath), File.ReadAllText(filePath));
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