using System.Collections.Generic;
using System.Linq;
using Phase11_ASP.Interfaces;

namespace Phase11_ASP.Implementations
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
                var queryType = query.First();
                switch (queryType)
                {
                    case '+':
                        plusContained.Add(query[1..]);
                        break;
                    case '-':
                        minusContained.Add(query[1..]);
                        break;
                    default:
                        withoutSignContained.Add(query);
                        break;
                }
            }

            return new QueryKeeper(plusContained, minusContained, withoutSignContained);
        }
    }
}