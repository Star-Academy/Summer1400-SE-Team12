using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;

namespace Phase05
{
    public class WithoutSignFilter : IFilter
    {
        private readonly IInvertedIndex _invertedIndex;

        public WithoutSignFilter(IInvertedIndex invertedIndex)
        {
            _invertedIndex = invertedIndex;
        }
        
        public HashSet<string> Filter(HashSet<string> signQueries)
        {
            var answer = new HashSet<string>();

            var WithoutSignFiltered = new HashSet<string>();

            bool firstTime = true;
            foreach (var signQueriesIterator in signQueries)
            {
                if (firstTime)
                {
                    WithoutSignFiltered= _invertedIndex.GetInvertedIndexValue(signQueriesIterator);
                    firstTime = false;

                }
                else
                {
                    IEnumerable<string> subscribesSets = from planet in WithoutSignFiltered.Intersect(
                            _invertedIndex.GetInvertedIndexValue(signQueriesIterator))
                        select planet;

                    foreach (var iterator in subscribesSets)
                    {
                        answer.Add(iterator);
                    }
                    
                }
                
            }
            
            return answer;
        }
        
        
        
    }
}