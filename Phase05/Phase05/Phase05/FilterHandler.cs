using System.Collections.Generic;

namespace Phase05
{
    public class FilterHandler : IFilterHandler
    {
        private readonly IFilter _conjunctionFilter;
        private readonly IFilter _disjunctionFilter;
        public FilterHandler(IFilter conjunctionFilter, IFilter disjunctionFilter)
        {
            _conjunctionFilter = conjunctionFilter;
            _disjunctionFilter = disjunctionFilter;
        }


        public HashSet<string> Filter(QueryKeeper queryKeeper)
        {
            var plusFiltered = _disjunctionFilter.Filter(queryKeeper.GetPlusContain());
            var minusFiltered = _disjunctionFilter.Filter(queryKeeper.GetMinusContain());
            var withoutSignFiltered = -_conjunctionFilter.Filter(queryKeeper.GetWithoutSignContain());
            
        }

        private HashSet<string> GeneralizeSignFiltered(HashSet<string> plusFiltered, HashSet<string> minusFiltere,
            HashSet<string> withoutSignFiltered)
        {
            var finalFiltered = new HashSet<string>(withoutSignFiltered);
            finalFiltered.re
        }
    }
}