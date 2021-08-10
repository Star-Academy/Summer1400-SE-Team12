using System;

namespace Phase08
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\ts\Desktop\EnglishData";
            using var invertedIndexContext = new InvertedIndexContext();
            invertedIndexContext.Database.EnsureCreated();
            
            FileReader fileReader = new FileReader(invertedIndexContext.DocumentsDbContext ,  invertedIndexContext.WordsDbContext);
           fileReader.ReadFile(path);
           invertedIndexContext.SaveChanges();
           //<TargetFramework>net5.0</TargetFramework>
        }
    }
}
