using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using SQLHandler;

namespace Phase08
{
    public class FileReader : IFileReader
    {
        private DbSet<Document> _documentsDbSet;

        public FileReader(DbSet<Document> documentsDbSet)
        {
            _documentsDbSet = documentsDbSet;
        }

        public void ReadFile(string path)
        {
            try
            {
                foreach (string filePath in Directory.GetFiles(path))
                    _documentsDbSet.Add(new Document()
                        {
                            DocName = Path.GetFileName(filePath), DocContents = File.ReadAllText(filePath)
                        }
                    );
            }
            catch (FileNotFoundException filException)
            {
                Console.WriteLine(filException);
                Environment.Exit(1);
            }
        }
        
    }
}