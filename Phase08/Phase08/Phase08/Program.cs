using System;

namespace Phase08
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\programming\code-star\Summer1400-SE-Team12\Phase03\EnglishData";
            using var invertedIndexContext = new InvertedIndexContext();
            invertedIndexContext.Database.EnsureCreated();
            
            FileReader fileReader = new FileReader(invertedIndexContext.DocumentsDbContext);
            InvertedIndex invertedIndex = new InvertedIndex(invertedIndexContext.WordsDbContext);
            fileReader.ReadFile(path);
           invertedIndexContext.SaveChanges();
           invertedIndex.BuildInvertedIndex(invertedIndexContext.DocumentsDbContext);
           invertedIndexContext.SaveChanges();
           //<TargetFramework>net5.0</TargetFramework>
        }
    }
}
