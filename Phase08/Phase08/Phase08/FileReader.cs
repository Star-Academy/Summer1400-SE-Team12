using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

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