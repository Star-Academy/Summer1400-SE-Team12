using System.Collections.Generic;
using System.Linq;
using Phase08;
using SQLHandler;
using Xunit;

namespace TestEFCorePhase08
{
    public class InvertedIndexTest
    {
        private readonly Dictionary<string, string> _docNameMapToContent;
        private readonly InvertedIndex _invertedIndex;
        private readonly InvertedIndexContext _context;


        public InvertedIndexTest()
        {
            _context = ContextFactory.CreateContext();
            _invertedIndex = new InvertedIndex(_context);
        }
        
        public static IEnumerable<object[]> BuildInvertedIndexTestData()
        {
            yield return new object[] { new HashSet<string> { "text2" }, "six" };
            yield return new object[] { new HashSet<string> {"text1","text3"}, "one" };
            yield return new object[] { new HashSet<string>() , "ten" };
        }
        
        [Theory, MemberData(nameof(BuildInvertedIndexTestData))]
        public void BuildInvertedIndexShouldCheckWordCorrectlyMappedToDocs(ISet<string> expectedDocContain, string searchingWord)
        {
            var docNameMapToContent = new Dictionary<string, string>
            {
                {"text1", "one two"}, {"text2", "five six seven eight nine"}, {"text3", "one two three"}
            };
            _invertedIndex.BuildInvertedIndex(docNameMapToContent);
            var actual = _context.WordsDbContext.Find(searchingWord)?.
                DocsCollection?.Select(w => w.DocName) ?? new HashSet<string>();
            Assert.Equal(expectedDocContain, actual);
        }
        
    }
}