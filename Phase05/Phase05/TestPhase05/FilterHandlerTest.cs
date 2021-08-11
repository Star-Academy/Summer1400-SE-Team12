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
        private QueryKeeper _queryKeeper;

        public FilterHandlerTest()
        {
            _conjunctionFilter = Substitute.For <IFilter>();
            _disjunctionFilter = Substitute.For<IFilter>();
            _filterHandler = new FilterHandler(_conjunctionFilter, _disjunctionFilter);
        }

        [Fact]
        public void FilterTest_queryKeeperContainsAllTypesOfFilter()
        {
            SetupQueryKeeper();
            var expectedValue = new HashSet<string>() {"doc4", "doc7"};
            var actualValue = _filterHandler.Filter(_queryKeeper);
            Assert.Equal(expectedValue,actualValue);
        }

        private void SetupQueryKeeper()
        {
            var minusQuery = new HashSet<string>() {"minus"};
            var plusQuery = new HashSet<string>() {"plus"};
            SetupIFilterFilterMethod(minusQuery,plusQuery);
            _queryKeeper = new QueryKeeper(plusQuery, minusQuery,new HashSet<string>());
        }
        
        private void SetupIFilterFilterMethod(ISet<string> minusQuery,ISet<string> plusQuery)
        {
            var conjunctionReturnValue = new HashSet<string>() {"doc1", "doc2", "doc4", "doc7"};
            var plusFilterReturnValue = new HashSet<string>() {"doc2", "doc4", "doc6", "doc7", "doc10"};
            var minusFilterReturnValue = new HashSet<string>() {"doc2", "doc8"}; 
            _conjunctionFilter.Filter(Arg.Any<ISet<string>>()).Returns(conjunctionReturnValue);
            _disjunctionFilter.Filter(plusQuery).Returns(plusFilterReturnValue);
            _disjunctionFilter.Filter(minusQuery).Returns(minusFilterReturnValue);
        }
        
    }
}