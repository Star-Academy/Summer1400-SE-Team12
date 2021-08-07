using System.Collections.Generic;

namespace Phase05
{
    public class QueryKeeper : IQueryKeeper
    {
        private readonly HashSet<string> _plusContain;
        private readonly HashSet<string> _minusContain;
        private readonly HashSet<string> _withOutSignContain;
        public QueryKeeper(HashSet<string> plusContain, HashSet<string> minusContain, HashSet<string> withOutSignContain)
        {
            _plusContain = plusContain;
            _minusContain = minusContain;
            _withOutSignContain = withOutSignContain;
        }


        public HashSet<string> GetPlusContain()
        {
            return _plusContain;
        }

        public HashSet<string> GetMinusContain()
        {
            return _minusContain;
        }

        public HashSet<string> GetWithoutSignContain()
        {
            return _withOutSignContain;
        }
        
    }
}