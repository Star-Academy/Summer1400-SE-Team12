using System.Collections.Generic;
using Phase05;
using Xunit;

namespace TestPhase05
{
    public class FileReaderTest
    {
        private readonly FileReader _fileReader;

        public FileReaderTest()
        {
            _fileReader = new FileReader();
        }

        [Fact]
        public void ReadFileShouldReturnDictionaryThatContainOneTxtFile()
        {
            string path = "TestFiles";
            
            var fileNameExpected = "one.txt";
            var contentExpected = "A woman finds a pot of treasure";
            var documents = _fileReader.ReadFile(path);
            
            Assert.True(documents.ContainsKey(fileNameExpected));
            Assert.Equal(contentExpected, documents.GetValueOrDefault(fileNameExpected));
        }
        
        [Fact]
        public void ReadFileShouldReturnDictionaryThatContainTwoTxtFile()
        {
            const string path = "TestFiles";
            
            const string fileNameExpected = "two.txt";
            const string  contentExpected = "Earth has been destroyed by war and no one lives on it anymore.";
            var documents = _fileReader.ReadFile(path);
            
            Assert.True(documents.ContainsKey(fileNameExpected));
            Assert.Equal(contentExpected, documents.GetValueOrDefault(fileNameExpected));
        }

    }
}