using System.Collections.Generic;
using Phase08;
using Xunit;

namespace TestPhase08
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
        public void TestBuildInvertedIndex_WordExistInADoc() {
            _invertedIndex.BuildInvertedIndex(_docNameMapToContent);
            Assert.Equal(new HashSet<string>(){"text2"}, 
                _invertedIndex.GetInvertedIndexValue("six"));

        }

        [Fact]
        public void TestBuildInvertedIndex_WordExistInTwoDoc() {
            _invertedIndex.BuildInvertedIndex(_docNameMapToContent);
            Assert.Equal(new HashSet<string>(){"text3", "text1"},
                _invertedIndex.GetInvertedIndexValue("one"));

        }

        [Fact]
        public void TestBuildInvertedIndex_WordNotExistInDoc() {
            _invertedIndex.BuildInvertedIndex(_docNameMapToContent);
            Assert.Equal(new HashSet<string>(),
                _invertedIndex.GetInvertedIndexValue("ten"));

        }
    }
}