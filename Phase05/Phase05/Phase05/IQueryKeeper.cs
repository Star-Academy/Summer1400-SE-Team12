using System.Collections.Generic;

namespace Phase05
{
    public interface IQueryKeeper
    {
        HashSet<string> GetPlusContain();
        HashSet<string> GetMinusContain();
        HashSet<string> GetWithoutSignContain();
        
    }
}