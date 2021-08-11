using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Phase05
{
    public class InvertedIndex : IInvertedIndex
    {
        private Dictionary<string, HashSet<string>> _invertedIndexMap = new Dictionary<string, HashSet<string>>();

        public void BuildInvertedIndex(Dictionary<string, string> docMapToContent)
        {
            foreach (var doc in docMapToContent)
            {
                var words = SplitDocumentsWords(doc.Value);
                AddDocumentWords(doc.Key, words);
            }
        }

        private string[] SplitDocumentsWords(string docContent)
        {
            return Regex.Split(docContent,"[\\W]+");
        }

        private void AddDocumentWords(string docName, string[] docWords)
        {
            foreach (var word in docWords)
            {
                if (_invertedIndexMap.ContainsKey(word))
                    _invertedIndexMap[word].Add(docName);
                else
                    _invertedIndexMap.Add(word, new HashSet<string> {docName});
            }
        }


        public HashSet<string> GetValueOfInvertedIndexKey(string key)
        {
            return _invertedIndexMap.GetValueOrDefault(key, new HashSet<string>());
        }
    }
}