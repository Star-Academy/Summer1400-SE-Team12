using System.Collections.Generic;
using System.Linq;

namespace Phase05
{
    public class QueryCategorizer : IQueryCategorizer
    {
        public QueryKeeper CategorizeQueries(string[] queries)
        {
            var plusContained = new HashSet<string>(); 
            var minusContained = new HashSet<string>(); 
            var withoutSignContained = new HashSet<string>();

            foreach (var query in queries)
            {
                if(query.Contains('+'))
                    plusContained.Add(query.Substring(1));
                else if(query.Contains('-'))
                    minusContained.Add(query.Substring(1));
                else 
                    withoutSignContained.Add(query);   
                    
                // var queryType = query.First();
                // switch (queryType)
                // {
                //     case '+': plusContained.Add(query.Substring(1));
                //         break;
                //     case '-': minusContained.Add(query.Substring(1));
                //         break;
                //     default : withoutSignContained.Add(query);    
                //         break;
                // }
            }

            return new QueryKeeper(plusContained, minusContained, withoutSignContained);
        }
    }
}