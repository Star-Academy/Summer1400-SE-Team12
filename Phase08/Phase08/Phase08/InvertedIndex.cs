using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SQLHandler;

namespace Phase08
{
    public class InvertedIndex : IInvertedIndex
    {
        // private Dictionary<string, HashSet<string>> _invertedIndexMap = new Dictionary<string, HashSet<string>>();

        private InvertedIndexContext _invertedIndexContext;
        // private DbSet<Word> _wordDbSet;

        public InvertedIndex(InvertedIndexContext invertedIndexContext)
        {
            _invertedIndexContext = invertedIndexContext;
        }

        public void BuildInvertedIndex(ISet<Document> documents)
        {
            foreach (var doc in documents)
            {
                var words = Regex.Split(doc.DocContents, "[\\W]+");
                foreach (var wordIterator in words)
                {
                    var word = _invertedIndexContext.WordsDbContext.Find(wordIterator);

                    if (word == null)
                    {
                        _invertedIndexContext.WordsDbContext.Add(new Word()
                        {
                            eachWord = wordIterator, DocsCollection = new HashSet<Document>() {doc}
                        });
                        _invertedIndexContext.SaveChanges();
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