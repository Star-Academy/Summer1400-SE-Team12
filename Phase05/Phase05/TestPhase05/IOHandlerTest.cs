using System;
using System.Collections.Generic;
using Phase05;
using Xunit;

namespace TestPhase05
{
    public class IOHandlerTest
    {

        [Fact]
        public void HandleIOTest_shouldReturnSetOfSplittedQuery()
        {
            var ioHandler = new IOHandler();
            var queries = new HashSet<string>();
            var sentence = "Hi -my -name is +Neda";
            var lowerSentence = sentence.ToLower();
            foreach (var eachWord in lowerSentence.Split(" "))
            {
                queries.Add(eachWord);
            }
            
            Assert.Equal(ioHandler.HandleIO().Contains("Hi"), true);
            Assert.Equal(ioHandler.HandleIO().Contains("+Neda"), true);

        }



    }
}

