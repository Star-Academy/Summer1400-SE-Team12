using System.Collections.Generic;

namespace Phase05
{
    public class InvertedIndex : IInvertedIndex
    {
        private Dictionary<string, HashSet<string>> _invertedIndexMap = new Dictionary<string, HashSet<string>>(); 
        public HashSet<string> GetInvertedIndexValue(string key)
        {
            throw new System.NotImplementedException();
        }

        public void BuildInvertedIndex(Dictionary<string, string> docMapToContent)
        {
        }
    }
}