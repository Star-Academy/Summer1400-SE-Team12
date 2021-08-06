using System;
using NSubstitute;
using Phase05;
using Xunit;

namespace TestPhase05
{
    public class QueryCategorizerTest
    {
        private readonly IQueryCategorizer _queryCategorizer;

        public QueryCategorizerTest()
        {
            _queryCategorizer = new QueryCategorizer();
        }
        
        [Fact]
        public void TestCategorize_ForNoSignQueries() {
            string[] queries = {"mom","dad","+sister","+sisi","-brother","-bro"};
            _queryCategorizer.CategorizeQueries(queries);
            Assert.assertArrayEquals(new String[]{"dad","mom"},
                _queryCategorizer.getQueryKeeper().getWithOutSign().toArray());

        }

        [Fact]
        public void testCategorizeForPlusQueries() {
            _queryCategorizer.categorizeQuery();
            Assert.assertArrayEquals(new String[]{"sisi","sister"},
                _queryCategorizer.getQueryKeeper().getPlusContain().toArray());

        }

        [Fact]
        public void testCategorizeForMinusQueries() {
            _queryCategorizer.categorizeQuery();
            Assert.assertArrayEquals(new String[]{"brother","bro"},
                _queryCategorizer.getQueryKeeper().getMinusContain().toArray());

        }
    }
}