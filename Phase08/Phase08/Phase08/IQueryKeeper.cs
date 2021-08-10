using System.Collections.Generic;

namespace Phase08
{
    public interface IQueryKeeper
    {
        HashSet<string> GetPlusContain();
        HashSet<string> GetMinusContain();
        HashSet<string> GetWithoutSignContain();
    }
}