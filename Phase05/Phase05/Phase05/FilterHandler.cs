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


        public ISet<string> Filter(IQueryKeeper queryKeeper)
        {
            var plusFiltered = _disjunctionFilter.Filter(queryKeeper.GetPlusContain());
            var minusFiltered = _disjunctionFilter.Filter(queryKeeper.GetMinusContain());
            var withoutSignFiltered = _conjunctionFilter.Filter(queryKeeper.GetWithoutSignContain());
            return GeneralizeSignFiltered(plusFiltered, minusFiltered, withoutSignFiltered);
        }

        private ISet<string> GeneralizeSignFiltered(ISet<string> plusFiltered, ISet<string> minusFiltered,
            ISet<string> withoutSignFiltered)
        {
            var finalFiltered = new HashSet<string>(withoutSignFiltered);
            return finalFiltered.Except(minusFiltered).Intersect(plusFiltered).ToHashSet();
        }
    }
}