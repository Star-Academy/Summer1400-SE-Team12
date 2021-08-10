using System;
using System.Collections.Generic;

namespace Phase08
{
    public class IOHandler : IIOHandler
    {
        private readonly FileReader _fileReader;

        public IOHandler(FileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public void ReadDocuments(string path)
        {
             _fileReader.ReadFile(path);
        }
        
        public string[] ReadQueries()
        {
            Console.WriteLine("Please enter a query");
            var queries = Console.ReadLine().ToLower().Split(" ");
            return queries;
        }

        public void PrintResultDocuments(ISet<string> answers)
        {
            if (answers.Count == 0)
                Console.WriteLine("We didn't find");
            else
                foreach (var answer in answers)
                    Console.Write(answer + "  ");
            
        }
    }
}