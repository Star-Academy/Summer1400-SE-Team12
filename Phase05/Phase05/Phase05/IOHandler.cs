using System;
using System.Collections.Generic;

namespace Phase05
{
    public class IOHandler : IIOHandler
    {
        public string[] ReadQueries()
        {
            Console.WriteLine("Please enter a query");
            var queries = Console.ReadLine().ToLower().Split(" ");
            return queries;
        }

        public void PrintResultDocuments()
        {
            
        }
    }
}