using System.Collections.Generic;
using Phase08;
using Xunit;

namespace TestPhase08
{
    public class FileReaderTest
    {
        private readonly FileReader _fileReader;

        public FileReaderTest()
        {
            _fileReader = new FileReader();
        }

        [Fact]
        public void ReadFileTest_shouldReturnDictionaryThatContainOneTxtFile()
        {
            string path = "TestFiles";
            
            var fileNameExpected = "one.txt";
            var contentExpected = "A woman finds a pot of treasure";
            Dictionary<string,string> documents = _fileReader.ReadFile(path);
            
            Assert.True(documents.ContainsKey(fileNameExpected));
            Assert.Equal(contentExpected, documents.GetValueOrDefault(fileNameExpected));
        }
        
        [Fact]
        public void ReadFileTest_shouldReturnDictionaryThatContainTwoTxtFile()
        {
            string path = "TestFiles";
            
            var fileNameExpected = "two.txt";
            var contentExpected = "Earth has been destroyed by war and no one lives on it anymore.";
            Dictionary<string,string> documents = _fileReader.ReadFile(path);
            
            Assert.True(documents.ContainsKey(fileNameExpected));
            Assert.Equal(contentExpected, documents.GetValueOrDefault(fileNameExpected));
        }

    }
}