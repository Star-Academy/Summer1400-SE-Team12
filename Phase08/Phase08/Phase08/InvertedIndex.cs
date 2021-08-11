using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace Phase08
{
    public class InvertedIndex : IInvertedIndex
    {
        // private Dictionary<string, HashSet<string>> _invertedIndexMap = new Dictionary<string, HashSet<string>>();

        private DbSet<Word> _wordDbSet;

        public InvertedIndex(DbSet<Word> wordDbSet)
        {
            _wordDbSet = wordDbSet;
        }

        public void BuildInvertedIndex(ISet<Document> documents, InvertedIndexContext invertedIndexContext)
        {
            foreach (var doc in documents)
            {
                var words = Regex.Split(doc.DocContents, "[\\W]+");
                foreach (var wordIterator in words)
                {
                    var word = _wordDbSet.Find(wordIterator);

                    if (word == null)
                    {
                        _wordDbSet.Add(new Word()
                        {
                            eachWord = wordIterator, DocsCollection = new HashSet<Document>() {doc}
                        });
                        invertedIndexContext.SaveChanges();
                    }
                    else
                    {
                        word.DocsCollection.Add(doc);
                        // invertedIndexContext.SaveChanges();
                    }
                }
                
            }
        }
        
    }
}