using System.Collections.Generic;

namespace Phase05
{
    public class QueryKeeper
    {
        public HashSet<string> _plusContain { get; set;}
        public HashSet<string> _minusContain { get; set; }
        public HashSet<string> _withoutSignContain { get; set; }
        public QueryKeeper(HashSet<string> plusContain, HashSet<string> minusContain, HashSet<string> withoutSignContain)
        {
            _plusContain = plusContain;
            _minusContain = minusContain;
            _withoutSignContain = withoutSignContain;
        }

        
        
    }
}