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
                    //WithoutSignFiltered.
                    //TODO eshterak bgir
                }
                

            }
            
            return WithoutSignFiltered;
        }
        
        
        
    }
}