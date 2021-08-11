using System.Collections.Generic;
using Phase05;
using Xunit;

namespace TestPhase05
{
    public class InvertedIndexTest
    {
        private readonly InvertedIndex _invertedIndex;


        public InvertedIndexTest()
        {
            _invertedIndex = new InvertedIndex();
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
                {"text1", "one two"}, {"text2", "five six seven eight nine"}, {"text3", "one two three "}
            };
            _invertedIndex.BuildInvertedIndex(docNameMapToContent);
            var actual = _invertedIndex.GetValueOfInvertedIndexKey(searchingWord);
            Assert.Equal(expectedDocContain, actual);
        }



    }
}