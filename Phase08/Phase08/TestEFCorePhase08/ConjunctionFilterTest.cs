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
        private readonly InvertedIndexContext _context;

        public ConjunctionFilterTest()
        {
            _context = ContextFactory.CreateContext();
            _conjunctionFilter = new ConjunctionFilter(_context.WordsDbContext);
        }


        [Fact]
        public void FilterTest_shouldReturnDocumentsThatContainSingleQuery()
        {
            var expected = new HashSet<string>() {"doc3"};
            var withoutSignFilterQuery = new HashSet<string>() {"hello", "bye"};
            var actual = _conjunctionFilter.Filter(withoutSignFilterQuery);
            Assert.Equal(expected, actual);
            
        }
        



    }
}