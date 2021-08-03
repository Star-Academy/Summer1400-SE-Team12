using System.Collections.Generic;
using NSubstitute;
using Phase05;
using Xunit;

namespace TestPhase05
{
    public class WithoutSignFilterTest
    {
        private readonly WithoutSignFilter withoutSignFilter;
        private readonly IInvertedIndex _invertedIndex;

        public WithoutSignFilterTest()
        {
            _invertedIndex = Substitute.For<IInvertedIndex>();
            var withoutSignFilter= new WithoutSignFilter(_invertedIndex);
        }


        [Fact]
        public void FilterTest_shouldReturnDocumentsThatContainSingleQuery()
        {
            
            var expected = new HashSet<string>() {"s3"};
            var withoutSignFilterQuery = new HashSet<string>() {"hello", "bye"};
            SetupInvertedIndexGetMethod();
            var actual = withoutSignFilter.Filter(withoutSignFilterQuery);
            Assert.Equal(expected, actual);
            
        }

        
        private void SetupInvertedIndexGetMethod()
        {
            _invertedIndex.GetInvertedIndexValue("hello").Returns(new HashSet<string>() {"s1", "s2", "s3"});
            _invertedIndex.GetInvertedIndexValue("bye").Returns(new HashSet<string>() {"s3", "s4", "s5"});
        }



    }
}