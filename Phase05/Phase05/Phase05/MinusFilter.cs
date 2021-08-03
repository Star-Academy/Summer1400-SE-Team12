﻿using System.Collections.Generic;
using System.Linq;

namespace Phase05
{
    public class MinusFilter : IFilter
    {
        private readonly IInvertedIndex _invertedIndex;

        public MinusFilter(IInvertedIndex invertedIndex)
        {
            _invertedIndex = invertedIndex;
        }
        
        public HashSet<string> Filter(HashSet<string> minusQueries)
        {
            var minusFiltered = new HashSet<string>();
            foreach (var s in minusQueries.Select(query => _invertedIndex.GetInvertedIndexValue(query)).SelectMany(set => set))
            {
                minusFiltered.Add(s);
            }
            return minusFiltered;
        }
        
    }
}