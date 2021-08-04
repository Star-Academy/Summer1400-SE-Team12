using System.Collections.Generic;

namespace Phase05
{
    public class QueryKeeper
    {
        private HashSet<string> plusContain;
        private HashSet<string> minusContain;
        private HashSet<string> withOutSignContain;


        public HashSet<string> GetPlusContain()
        {
            return plusContain;
        }
        
        public HashSet<string> GetMinusContain()
        {
            return minusContain;
        }
        
        public HashSet<string> GetWithoutSignContain()
        {
            return withOutSignContain;
        }
    }
}