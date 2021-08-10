// using System.Collections.Generic;
// using System.Linq;
//
// namespace Phase08
// {
//     public class DisjunctionFilter : IFilter
//     {
//         private readonly IInvertedIndex _invertedIndex;
//
//         public DisjunctionFilter(IInvertedIndex invertedIndex)
//         {
//             _invertedIndex = invertedIndex;
//         }
//         
//         public ISet<string> Filter(ISet<string> signQueries)
//         {
//             var disjunctionFiltered = new HashSet<string>();
//
//             return signQueries.Aggregate(disjunctionFiltered, (current, query) =>
//                 current.Union(_invertedIndex.GetInvertedIndexValue(query)).ToHashSet());
//         }
//         
//     }
// }