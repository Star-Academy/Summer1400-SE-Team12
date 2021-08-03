using System;
using System.Collections.Generic;

namespace Phase05
{
    public class InvertedIndex : IInvertedIndex
    {
        private Dictionary<string, HashSet<string>> _invertedIndexMap = new Dictionary<string, HashSet<string>>(); 
        public HashSet<string> GetInvertedIndexValue(string key)
        {
            return _invertedIndexMap.GetValueOrDefault(key);
        }

        public void BuildInvertedIndex(Dictionary<string, string> docMapToContent)
        {
            foreach (var doc in docMapToContent)
            {
                var words = doc.Value.Split("[\\W]+");
                foreach (var wordsIterator in words)
                {
                    if (_invertedIndexMap.ContainsKey(wordsIterator))
                    {
                        _invertedIndexMap.GetValueOrDefault(wordsIterator).Add(doc.Key);
                    }
                    else
                    {
                        var docNames = new HashSet<string>(){doc.Key};
                        _invertedIndexMap.Add(wordsIterator,docNames);
                    }
                    
                }
                
                
                
            }
            
        }
        
        
        
    }
}