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
        private DbSet<Word> _wordsDbSet;

        public FileReader(DbSet<Document> documentsDbSet, DbSet<Word> wordsDbSet)
        {
            _documentsDbSet = documentsDbSet;
            _wordsDbSet = wordsDbSet;
        }

        public void ReadFile(string path)
        {
            try
            {
                foreach (string filePath in Directory.GetFiles(path))
                    _documentsDbSet.Add(new Document()
                        {
                            DocName = Path.GetFileName(filePath), DocContents = File.ReadAllText(filePath),
                            wordsCollection = SplitDocumentsWords(File.ReadAllText(filePath))
                        }
                    );
            }
            catch (FileNotFoundException filException)
            {
                Console.WriteLine(filException);
                Environment.Exit(1);
            }
        }


        private ISet<Word> SplitDocumentsWords(string docContent)
        {
            ISet<Word> words = new HashSet<Word>();
            foreach (var wordSplitted in Regex.Split(docContent, "[\\W]+"))
            {
               // var customer= dataContext.Customer.Where(x=>x.CustomerID==your_key).FirstOrDefault();
               var wordInDoc = _wordsDbSet.Where(w => w.eachWord == wordSplitted).FirstOrDefault();
               if (wordInDoc==null)
               {
                    var wordObj = new Word(wordSplitted,new HashSet<Document>());
               }
               else
               {
                   //_wordsDbSet.Update(new Word(wordSplitted) , wordInDoc.DocsCollection.Add())
               }
               
               

            }

            return words;
        }
    }
}