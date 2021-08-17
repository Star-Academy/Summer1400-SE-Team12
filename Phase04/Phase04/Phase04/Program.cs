using System;
using System.Collections.Generic;

namespace Phase4
{
    class Program
    {
        private const string PathStudents = @"JsonFiles\Students.json";
        private const string PathScores = @"JsonFiles\Scores.json";

        static void Main(string[] args)
        {
            var reader = new Reader();
            var averageEngine = new AverageEngine();
            var topStudentsIntroducer = new TopStudentsIntroducer(reader, averageEngine);
            var studentAverages = topStudentsIntroducer.
                GetTopStudents(3,PathStudents, PathScores);
            PrintTopStudents(studentAverages);
            
        }

        private static void PrintTopStudents(IEnumerable<StudentAverage> topStudents)
        {
            foreach (var topStudent in topStudents)
            {
                Console.WriteLine(topStudent.ToString());
            }
        }
    }

}
