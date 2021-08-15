using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NSubstitute;
using Phase08;
using SQLHandler;
using Xunit;

namespace TestEFCorePhase08
{
    public class DisjunctionFilterTest
    {
        private DisjunctionFilter _disjunctionFilter;
        private readonly InvertedIndexContext _context;

        public DisjunctionFilterTest()
        {
            _context = ContextFactory.CreateContext();
            _disjunctionFilter = new DisjunctionFilter(_context.WordsDbContext);
        }

         // private readonly IInvertedIndex _invertedIndex;

         // public DisjunctionFilterTest()
         // {
         //     // _invertedIndex = Substitute.For<IInvertedIndex>();
         //     // _disjunctionFilter = new DisjunctionFilter(_invertedIndex);
         //     DbContextOptionsBuilder<InvertedIndexContext> builder = new();
         //     builder.UseInMemoryDatabase("EfcorePhase08Project");
         //     _context = new InvertedIndexContext(builder.Options);
         //     
         // }

         [Fact]
         public void MinusFilterTest_shouldReturnRemovedDocumentsContainSingleQuery()
         {
             
            var expected = new HashSet<string>() {"doc1", "doc2", "doc3", "doc4", "doc5"};
            var minusQuery = new HashSet<string>() {"hello", "bye"};
            
            
            var actual = _disjunctionFilter.Filter(minusQuery);
            Assert.Equal(expected, actual);


            // // Use a clean instance of the context to run the test
            // using (var context = new MovieDbContext(options))
            // {
            //     MovieRepository movieRepository = new MovieRepository(context);
            //     List<Movies> movies == movieRepository.GetAll()
            //
            //     Assert.Equal(3, movies.Count);
            // }
            
            
        }

        // private void SetupInvertedIndexGetMethod()
        // {
        //     _invertedIndex.GetInvertedIndexValue("hello").Returns(new HashSet<string>() {"doc1", "doc2", "doc3"});
        //     _invertedIndex.GetInvertedIndexValue("bye").Returns(new HashSet<string>() {"doc3", "doc4", "doc5"});
        // }
    }
}