using System.Collections;
using System.Collections.Generic;
using Phase05;
using Xunit;

namespace TestPhase05
{
    public class FileReaderTest
    {
        [Fact]
        public void ReadFileTest_shouldReturnDictionaryThatContainNamesAndContent()
        {
            string path = @"C:\Users\ts\RiderProjects\Summer1400-SE-Team12\Phase05\Phase05\TestPhase05\testFile";
            var fileReader = new FileReader();
            var content = "the fox is hear.";
            var name = "testText.txt";

            Dictionary<string,string> documents = fileReader.ReadFile(path);
            
            Assert.Equal(documents.ContainsKey(name),true);
            Assert.Equal(documents.ContainsValue(content),true);

        }

    }
}