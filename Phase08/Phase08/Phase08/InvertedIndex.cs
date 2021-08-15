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
        private InvertedIndexContext _invertedIndexContext;

        public InvertedIndex(InvertedIndexContext invertedIndexContext)
        {
            _invertedIndexContext = invertedIndexContext;
        }

        public void BuildInvertedIndex(Dictionary<string, string> documents)
        {
            foreach (var doc in documents)
            {
                var words = Regex.Split(doc.Value, "[\\W]+");
                var docu = new Document(doc.Key, doc.Value);
                foreach (var wordIterator in words)
                {
                    var word = _invertedIndexContext.WordsDbContext.Find(wordIterator);
                    
                    if (word == null)
                    {
                        _invertedIndexContext.WordsDbContext.Add(new Word(wordIterator, new HashSet<Document>() {docu}));
                        _invertedIndexContext.SaveChanges();
                    }
                    else
                    {
                        word.DocsCollection.Add(docu);
                    }
                }
            }
            
        }
        
    }
}