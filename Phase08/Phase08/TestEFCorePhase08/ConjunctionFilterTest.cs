using System.Collections.Generic;
using NSubstitute;
using Phase08;
using SQLHandler;
using Xunit;

namespace TestEFCorePhase08
{
    public class ConjunctionFilterTest
    {
        private readonly ConjunctionFilter _conjunctionFilter;
        private readonly IInvertedIndexContextWrapper _contextContextWrapper;

        public ConjunctionFilterTest()
        {
            _contextContextWrapper = new InvertedIndexContextWrapper(ContextFactory.CreateContext());
            _conjunctionFilter = new ConjunctionFilter(_contextContextWrapper);
        }


        [Fact]
        public void FilterShouldReturnDocumentsThatContainSingleQuery()
        {
            var expected = new HashSet<string>() {"doc3"};
            var withoutSignQuery = new HashSet<string>() {"hello", "bye"};
            var actual = _conjunctionFilter.Filter(withoutSignQuery);
            Assert.Equal(expected, actual);
        }
        



    }
}