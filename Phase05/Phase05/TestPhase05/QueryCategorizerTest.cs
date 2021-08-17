using System.Collections.Generic;
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
        public void CategorizeShouldFillQueryKeeperProperlyWithTheirSign() {
            string[] queries = {"mom","dad","+sister","+sisi","-brother","-bro"};
            var categorized = _queryCategorizer.CategorizeQueries(queries);
            
            Assert.Equal(new HashSet<string>() {"sisi", "sister"},categorized._plusContain);
            Assert.Equal(new HashSet<string>() {"bro", "brother"},categorized._minusContain);
            Assert.Equal(new HashSet<string>() {"mom", "dad"},categorized._withoutSignContain);

        }
        
    }
}