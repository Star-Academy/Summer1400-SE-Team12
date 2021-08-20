using System;
using System.Collections.Generic;
using Phase11_ASP.Interfaces;

namespace Phase11_ASP.Implementations
{
    public class IOHandler : IIOHandler
    {
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
                Console.WriteLine(string.Join(" ", answers));
            
        }
    }
}