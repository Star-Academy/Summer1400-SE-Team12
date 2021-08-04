using System.Collections.Generic;
using NSubstitute;
using Phase05;
using Xunit;

namespace TestPhase05
{
    public class FilterHandlerTest
    {
        private readonly IFilterHandler _filterHandler;
        private readonly IFilter _conjunctionFilter;
        private readonly IFilter _disjunctionFilter;
        private readonly IQueryKeeper _queryKeeper;

        public FilterHandlerTest()
        {
            _queryKeeper = Substitute.For<IQueryKeeper>();
            _conjunctionFilter = Substitute.For <IFilter>();
            _disjunctionFilter = Substitute.For<IFilter>();
            _filterHandler = new FilterHandler(_conjunctionFilter, _disjunctionFilter);
            
        }

        [Fact]
        public void FilterTest_queryKeeperContainsAllTypesOfFilter()
        {
            
        }
        
        private void SetupQueryKeeperGetMethodsForAllTypes()
        {
            
        }
    }
}