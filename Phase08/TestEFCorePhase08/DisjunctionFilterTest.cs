using System.Collections.Generic;
using Phase08;
using SQLHandler;
using Xunit;

namespace TestEFCorePhase08
{
    public class DisjunctionFilterTest
    {
        private readonly DisjunctionFilter _disjunctionFilter;
        private readonly IInvertedIndexContextWrapper _contextContextWrapper;

        public DisjunctionFilterTest()
        {
            _contextContextWrapper = new InvertedIndexContextWrapper(ContextFactory.CreateContext());
            _disjunctionFilter = new DisjunctionFilter(_contextContextWrapper);
        }


        [Fact]
        public void MinusFilterShouldReturnRemovedDocumentsContainSingleQuery()
        {
            var expected = new HashSet<string>() {"doc1", "doc2", "doc3", "doc4", "doc5"};
            var minusQuery = new HashSet<string>() {"hello", "bye"};
            var actual = _disjunctionFilter.Filter(minusQuery);
            Assert.Equal(expected, actual);
        }
        
    }
}