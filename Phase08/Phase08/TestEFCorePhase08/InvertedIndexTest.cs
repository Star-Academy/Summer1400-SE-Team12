using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Phase08;
using SQLHandler;
using Xunit;

namespace TestEFCorePhase08
{
    public class InvertedIndexTest
    {
        private readonly DbSet<Word> _wordDbSet;
        private readonly Dictionary<string,string> _docNameMapToContent;


        public InvertedIndexTest()
        {
            
            _docNameMapToContent = new Dictionary<string, string>
            {
                {"text1", "one two"}, {"text2", "five six seven eight nine"}, {"text3", "one two three "}
            };

        }

        [Fact]
        public void TestBuildInvertedIndex_WordExistInADoc() {
            var options = new DbContextOptionsBuilder<InvertedIndexContext>()
                .UseInMemoryDatabase(databaseName: "EfcorePhase08Project")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new InvertedIndexContext())
            {
                context.WordsDbContext.Add(new Word());
                context.Movies.Add(new Movie {Id = 2, Title = "Movie 2", YearOfRelease = 2018, Genre = "Action"});
                context.Movies.Add(nnew Movie {Id = 3, Title = "Movie 3", YearOfRelease = 2019, Genre = "Action"});
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new MovieDbContext(options))
            {
                MovieRepository movieRepository = new MovieRepository(context);
                List<Movies> movies == movieRepository.GetAll()

                Assert.Equal(3, movies.Count);
            }
            // _invertedIndex.BuildInvertedIndex(_docNameMapToContent);
            // Assert.Equal(new HashSet<string>(){"text2"}, 
            //     _invertedIndex.GetInvertedIndexValue("six"));

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