using System.Collections.Generic;
using NSubstitute;
using Phase08;
using Xunit;

namespace TestEFCorePhase08
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
            var minusQuery = new HashSet<string>() {"minus"};
            var plusQuery = new HashSet<string>() {"plus"};
            SetupIQueryKeeper_GetMethods(minusQuery,plusQuery); 
            SetupIFilter_FilterMethod(minusQuery,plusQuery);
            var expectedValue = new HashSet<string>() {"doc4", "doc7"};
            var actualValue = _filterHandler.Filter(_queryKeeper);
            Assert.Equal(expectedValue,actualValue);
        }

        private void SetupIFilter_FilterMethod(ISet<string> m,ISet<string>p)
        {
            var conjunctionReturnValue = new HashSet<string>() {"doc1", "doc2", "doc4", "doc7"};
            var plusFilterReturnValue = new HashSet<string>() {"doc2", "doc4", "doc6", "doc7", "doc10"};
            var minusFilterReturnValue = new HashSet<string>() {"doc2", "doc8"}; 
            _conjunctionFilter.Filter(Arg.Any<ISet<string>>()).Returns(conjunctionReturnValue);
            _disjunctionFilter.Filter(p).Returns(plusFilterReturnValue);
            _disjunctionFilter.Filter(m).Returns(minusFilterReturnValue);
        }
        private void SetupIQueryKeeper_GetMethods(ISet<string> m,ISet<string>p)
        {
            _queryKeeper.GetMinusContain().Returns(m);
            _queryKeeper.GetPlusContain().Returns(p);
            _queryKeeper.GetWithoutSignContain().Returns(new HashSet<string>());
        }
    }
}