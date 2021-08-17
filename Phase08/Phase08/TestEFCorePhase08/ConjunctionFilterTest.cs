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
        private readonly IInvertedIndexWrapper _contextWrapper;

        public ConjunctionFilterTest()
        {
            _contextWrapper = new InvertedIndexWrapper(ContextFactory.CreateContext());
            _conjunctionFilter = new ConjunctionFilter(_contextWrapper);
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