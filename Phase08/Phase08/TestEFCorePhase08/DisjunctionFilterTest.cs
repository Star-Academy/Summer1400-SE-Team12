using System.Collections.Generic;
using Phase08;
using SQLHandler;
using Xunit;

namespace TestEFCorePhase08
{
    public class DisjunctionFilterTest
    {
        private readonly DisjunctionFilter _disjunctionFilter;
        private readonly InvertedIndexContext _context;

        public DisjunctionFilterTest()
        {
            _context = ContextFactory.CreateContext();
            _disjunctionFilter = new DisjunctionFilter(_context);
        }


        [Fact]
        public void MinusFilterTest_shouldReturnRemovedDocumentsContainSingleQuery()
        {
            var expected = new HashSet<string>() {"doc1", "doc2", "doc3", "doc4", "doc5"};
            var minusQuery = new HashSet<string>() {"hello", "bye"};
            var actual = _disjunctionFilter.Filter(minusQuery);
            Assert.Equal(expected, actual);
        }
        
    }
}