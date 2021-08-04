using System;
using System.Collections.Generic;

namespace Phase05
{
    public class IOHandler : IIOHandler
    {
        public HashSet<string> HandleIO()
      {
          var  result=new HashSet<string>();
          Console.WriteLine("Please enter a query");
          string input = Console.ReadLine();
          var lowerInput = input.ToLower();
          foreach (var eachWord in lowerInput.Split(" "))
          {
              result.Add(eachWord);
          }

          return result;
      }

    }
}