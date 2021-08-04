using System.Collections.Generic;
using NSubstitute;
using Phase05;
using Xunit;

namespace TestPhase05
{
    public class MinusFilterTest
    {
        private readonly MinusFilter _minusFilterSUT;
        private readonly IInvertedIndex _invertedIndex;

        public MinusFilterTest()
        {
            _invertedIndex = Substitute.For<IInvertedIndex>();
            _minusFilterSUT = new MinusFilter(_invertedIndex);
        }

        [Fact]
        public void MinusFilterTest_shouldReturnRemovedDocumentsContainSingleQuery()
        {
            var expected = new HashSet<string>() {"doc1", "doc2", "doc3", "doc4", "doc5"};
            var minusQuery = new HashSet<string>() {"hello", "bye"};
            SetupInvertedIndexGetMethod();
            var actual = _minusFilterSUT.Filter(minusQuery);
            Assert.Equal(expected, actual);
        }

        private void SetupInvertedIndexGetMethod()
        {
            _invertedIndex.GetInvertedIndexValue("hello").Returns(new HashSet<string>() {"doc1", "doc2", "doc3"});
            _invertedIndex.GetInvertedIndexValue("bye").Returns(new HashSet<string>() {"doc3", "doc4", "doc5"});
        }
    }
}