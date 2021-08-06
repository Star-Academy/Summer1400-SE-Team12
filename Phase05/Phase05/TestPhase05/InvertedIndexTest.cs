using System.Collections.Generic;
using Phase05;
using Xunit;

namespace TestPhase05
{
    public class InvertedIndexTest
    {
        private readonly InvertedIndex _invertedIndex;
        private readonly Dictionary<string,string> _docNameMapToContent;


        public InvertedIndexTest()
        {
            _invertedIndex = new InvertedIndex();
            _docNameMapToContent = new Dictionary<string, string>
            {
                {"text1", "one two"}, {"text2", "five six seven eight nine"}, {"text3", "one two three "}
            };

        }

        [Fact]
        public void testInvertedIndex_WordExistInADoc() {
            _invertedIndex.BuildInvertedIndex(_docNameMapToContent);
            Assert.Equal(new HashSet<string>(){"text2"}, 
                _invertedIndex.GetInvertedIndexValue("six"));

        }

        [Fact]
        public void testInvertedIndexWordExistInTwoDoc() {
            _invertedIndex.BuildInvertedIndex(_docNameMapToContent);
            Assert.Equal(new HashSet<string>(){"text3", "text1"},
                _invertedIndex.GetInvertedIndexValue("one"));

        }

        [Fact]
        public void testInvertedIndexWordNotExistInDoc() {
            _invertedIndex.BuildInvertedIndex(_docNameMapToContent);
            Assert.Equal(new HashSet<string>(),
                _invertedIndex.GetInvertedIndexValue("ten"));

        }
    }
}