using System.Collections.Generic;
using Phase08;
using SQLHandler;
using Xunit;

namespace TestEFCorePhase08
{
    public class InvertedIndexTest
    {
        private readonly Dictionary<string, string> _docNameMapToContent;
        private readonly InvertedIndex _invertedIndex;
        private readonly IInvertedIndexContextWrapper _contextContextWrapper;


        public InvertedIndexTest()
        {
            _contextContextWrapper = new InvertedIndexContextWrapper(ContextFactory.CreateContext());
            _invertedIndex = new InvertedIndex(_contextContextWrapper);
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
            var actual = _contextContextWrapper.GetDocumentsContainQuery(searchingWord);
            Assert.Equal(expectedDocContain, actual);
        }
        
    }
}