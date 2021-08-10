﻿using System.Collections.Generic;
using NSubstitute;
using Phase08;
using Xunit;

namespace TestPhase08
{
    public class ConjunctionFilterTest
    {
        private readonly ConjunctionFilter _conjunctionFilter;
        private readonly IInvertedIndex _invertedIndex;

        public ConjunctionFilterTest()
        {
            _invertedIndex = Substitute.For<IInvertedIndex>();
            _conjunctionFilter= new ConjunctionFilter(_invertedIndex);
        }


        [Fact]
        public void FilterTest_shouldReturnDocumentsThatContainSingleQuery()
        {
            var expected = new HashSet<string>() {"s3"};
            var withoutSignFilterQuery = new HashSet<string>() {"hello", "bye"};
            SetupInvertedIndexGetMethod();
            var actual = _conjunctionFilter.Filter(withoutSignFilterQuery);
            Assert.Equal(expected, actual);
            
        }
        
        private void SetupInvertedIndexGetMethod()
        {
            _invertedIndex.GetInvertedIndexValue("hello").Returns(new HashSet<string>() {"s1", "s2", "s3"});
            _invertedIndex.GetInvertedIndexValue("bye").Returns(new HashSet<string>() {"s3", "s4", "s5"});
        }



    }
}