using System.Collections.Generic;
using System.Linq;

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


        public ISet<string> Filter(QueryKeeper queryKeeper)
        {
            var plusFiltered = _disjunctionFilter.Filter(queryKeeper._plusContain);
            var minusFiltered = _disjunctionFilter.Filter(queryKeeper._minusContain);
            var withoutSignFiltered = _conjunctionFilter.Filter(queryKeeper._withoutSignContain);
            var finalFiltered = ExecuteFilterRelatedToSign(plusFiltered, minusFiltered, withoutSignFiltered);
            return finalFiltered;
        }

        private ISet<string> ExecuteFilterRelatedToSign(IEnumerable<string> plusFiltered, IEnumerable<string> minusFiltered,
            IEnumerable<string> withoutSignFiltered)
        {
            var finalFiltered = new HashSet<string>(withoutSignFiltered);
            return finalFiltered.Except(minusFiltered).Intersect(plusFiltered).ToHashSet();
        }
    }
}