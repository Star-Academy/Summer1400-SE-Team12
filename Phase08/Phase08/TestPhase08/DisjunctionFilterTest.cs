using System.Collections.Generic;
using NSubstitute;
using Phase08;
using Xunit;

namespace TestPhase08
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
        public void MinusFilterTest_shouldReturnRemovedDocumentsContainSingleQuery()
        {
            var expected = new HashSet<string>() {"doc1", "doc2", "doc3", "doc4", "doc5"};
            var minusQuery = new HashSet<string>() {"hello", "bye"};
            SetupInvertedIndexGetMethod();
            var actual = _disjunctionFilter.Filter(minusQuery);
            Assert.Equal(expected, actual);
        }

        private void SetupInvertedIndexGetMethod()
        {
            _invertedIndex.GetInvertedIndexValue("hello").Returns(new HashSet<string>() {"doc1", "doc2", "doc3"});
            _invertedIndex.GetInvertedIndexValue("bye").Returns(new HashSet<string>() {"doc3", "doc4", "doc5"});
        }
    }
}