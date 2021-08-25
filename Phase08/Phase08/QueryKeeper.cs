using System.Collections.Generic;

namespace Phase08
{
    public class QueryKeeper
    {
        public HashSet<string> PlusContain { get;}
        public HashSet<string> MinusContain { get;}
        public HashSet<string> WithoutSignContain { get;}
        public QueryKeeper(HashSet<string> plusContain, HashSet<string> minusContain, HashSet<string> withoutSignContain)
        {
            PlusContain = plusContain;
            MinusContain = minusContain;
            WithoutSignContain = withoutSignContain;
        }

        
        
    }
}