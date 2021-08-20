using System.Collections.Generic;

namespace Phase11_ASP.Implementations
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