using System.Collections.Generic;

namespace Phase11_ASP.Implementations
{
    public class QueryKeeper
    {
        public ISet<string> PlusContain { get;}
        public ISet<string> MinusContain { get;}
        public ISet<string> WithoutSignContain { get;}
        public QueryKeeper(ISet<string> plusContain, ISet<string> minusContain, ISet<string> withoutSignContain)
        {
            PlusContain = plusContain;
            MinusContain = minusContain;
            WithoutSignContain = withoutSignContain;
        }

        
        
    }
}