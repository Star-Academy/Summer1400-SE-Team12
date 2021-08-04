using System.Collections.Generic;

namespace Phase05
{
    public class FilterHandler : IFilterHandler
    {
        private readonly ConjunctionFilter _conjunctionFilter;
        private readonly DisjunctionFilter _disjunctionFilter;
        public FilterHandler(ConjunctionFilter conjunctionFilter, DisjunctionFilter disjunctionFilter)
        {
            _conjunctionFilter = conjunctionFilter;
            _disjunctionFilter = disjunctionFilter;
        }


        public HashSet<string> Filter()
        {
            throw new System.NotImplementedException();
        }
    }
}