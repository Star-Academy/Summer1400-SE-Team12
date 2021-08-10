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

        public void BuildInvertedIndex(DbSet<Document> documents)
        {
            foreach (var doc in documents)
            {
                var words = Regex.Split(doc.DocContents, "[\\W]+");
                foreach (var wordIterator in words)
                {
                    var containWord = _wordDbSet.FirstOrDefault(w => w.eachWord == wordIterator);
                    if (containWord == null)
                    {
                        _wordDbSet.Add(new Word()
                        {
                            eachWord = wordIterator, DocsCollection = new HashSet<Document>() {doc}
                        });
                    }
                    else
                    {
                        var word = _wordDbSet.Find(wordIterator);
                        word.DocsCollection.Add(doc);
                        // var docs = 
                        // _wordDbSet.Update(new Word(){eachWord = wordIterator, DocsCollection = word.DocsCollection.Add(doc)})
                    }
                }
                // var words = SplitDocumentsWords(doc.DocContents);
                // AddDocumentWords(doc.Key, words);
            }
        }

        // private string[] SplitDocumentsWords(string docContent)
        // {
        //     return
        // }
        //
        // private void AddDocumentWords(string docName, string[] docWords)
        // {
        //     foreach (string word in docWords)
        //     {
        //         if (_invertedIndexMap.ContainsKey(word))
        //             _invertedIndexMap.GetValueOrDefault(word, new HashSet<string>()).Add(docName);
        //         else
        //             _invertedIndexMap.Add(word, new HashSet<string> {docName});
        //     }
        // }
        //
        //
        // public HashSet<string> GetInvertedIndexValue(string key)
        // {
        //     return _invertedIndexMap.GetValueOrDefault(key, new HashSet<string>());
        // }
    }
}