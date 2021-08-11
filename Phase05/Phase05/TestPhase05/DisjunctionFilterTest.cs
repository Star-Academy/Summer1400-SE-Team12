using System.Collections.Generic;
using NSubstitute;
using Phase05;
using Xunit;

namespace TestPhase05
{
    public class DisjunctionFilterTest
    {
        private readonly DisjunctionFilter _disjunctionFilter;
        private readonly IInvertedIndex _invertedIndex;

        public DisjunctionFilterTest()
        {
            _invertedIndex = Substitute.For<IInvertedIndex>();
            _disjunctionFilter = new DisjunctionFilter(_invertedIndex);
        }

        [Fact]
        public void MinusFilterShouldReturnRemovedDocumentsContainSingleQuery()
        {
            var expected = new HashSet<string>() {"doc1", "doc2", "doc3", "doc4", "doc5"};
            var minusQuery = new HashSet<string>() {"hello", "bye"};
            SetupInvertedIndexGetMethod();
            var actual = _disjunctionFilter.Filter(minusQuery);
            Assert.Equal(expected, actual);
        }

        private void SetupInvertedIndexGetMethod()
        {
            _invertedIndex.GetValueOfInvertedIndexKey("hello").Returns(new HashSet<string>() {"doc1", "doc2", "doc3"});
            _invertedIndex.GetValueOfInvertedIndexKey("bye").Returns(new HashSet<string>() {"doc3", "doc4", "doc5"});
        }
    }
}