using System.Collections.Generic;
using Phase05;
using Xunit;

namespace TestPhase05
{
    public class InvertedIndexTest
    {
        private readonly InvertedIndex _invertedIndex;
        private Dictionary<string,string> _docNameMapToContent;


        public InvertedIndexTest()
        {
            _invertedIndex = new InvertedIndex();
            InitializeDocNameMapToContent();
        }

        private void InitializeDocNameMapToContent()
        {
            _docNameMapToContent = new Dictionary<string, string>
            {
                {"text1", "one two"}, {"text2", "five six seven eight nine"}, {"text3", "one two three "}
            };
        }

        [Fact]
        public void BuildInvertedIndexTest_CheckIfWordExistInJustOneDoc() {
            _invertedIndex.BuildInvertedIndex(_docNameMapToContent);
            var expected = new HashSet<string>() {"text2"};
            var actual = _invertedIndex.GetInvertedIndexValue("six");
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void BuildInvertedIndexTest_CheckIfWordExistInTwoDoc() {
            _invertedIndex.BuildInvertedIndex(_docNameMapToContent);
            var expected = new HashSet<string>() {"text3", "text1"};
            var actual = _invertedIndex.GetInvertedIndexValue("one");
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void BuildInvertedIndexTest_CheckIfWordNotExistInDoc() {
            _invertedIndex.BuildInvertedIndex(_docNameMapToContent);
            var expected = new HashSet<string>();
            var actual = _invertedIndex.GetInvertedIndexValue("ten");
            Assert.Equal(expected,actual);

        }
    }
}