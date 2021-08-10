using System;

namespace Phase08
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\ts\Desktop\EnglishData";
            using var invertedIndexContext = new InvertedIndexContext();
            
            FileReader fileReader = new FileReader(invertedIndexContext.DocumentsDbContext ,  invertedIndexContext.WordsDbContext);
           fileReader.ReadFile(path);
            //<TargetFramework>net5.0</TargetFramework>
        }
    }
}
