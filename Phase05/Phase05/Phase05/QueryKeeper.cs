using System.Collections.Generic;

namespace Phase05
{
    public class QueryKeeper
    {
        public HashSet<string> _plusContain { get;}
        public HashSet<string> _minusContain { get;}
        public HashSet<string> _withoutSignContain { get;}
        public QueryKeeper(HashSet<string> plusContain, HashSet<string> minusContain, HashSet<string> withoutSignContain)
        {
            _plusContain = plusContain;
            _minusContain = minusContain;
            _withoutSignContain = withoutSignContain;
        }

        
        
    }
}