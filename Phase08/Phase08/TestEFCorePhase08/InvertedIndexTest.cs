using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Phase08;
using SQLHandler;
using Xunit;

namespace TestEFCorePhase08
{
    public class InvertedIndexTest
    {
        private readonly Dictionary<string,string> _docNameMapToContent;
        private InvertedIndexContext _context;


        public InvertedIndexTest()
        {
            var options = new DbContextOptionsBuilder<InvertedIndexContext>()
                 .UseInMemoryDatabase( "EfcorePhase08Project")
                 .Options;
            _context = new InvertedIndexContext(options);
            _docNameMapToContent = new Dictionary<string, string>
            {
                {"text1", "one two"}, {"text2", "five six seven eight nine"}, {"text3", "one two three "}
            };

        }

        [Fact]
        public void TestBuildInvertedIndex_WordExistInADoc() {
            var invertedIndex = new InvertedIndex(_context);
            invertedIndex.BuildInvertedIndex(_docNameMapToContent);
            
            Assert.Equal(new HashSet<string>(){"text2"}, 
                _context.WordsDbContext.Find("six")?.DocsCollection.Select(w => w.DocName));
        }

        
        
        
        
        
        
        // [Fact]
        // public void TestBuildInvertedIndex_WordExistInTwoDoc() {
        //     _invertedIndex.BuildInvertedIndex(_docNameMapToContent);
        //     Assert.Equal(new HashSet<string>(){"text3", "text1"},
        //         _invertedIndex.GetInvertedIndexValue("one"));
        //
        // }
        //
        // [Fact]
        // public void TestBuildInvertedIndex_WordNotExistInDoc() {
        //     _invertedIndex.BuildInvertedIndex(_docNameMapToContent);
        //     Assert.Equal(new HashSet<string>(),
        //         _invertedIndex.GetInvertedIndexValue("ten"));
        //
        // }
    }
}