using System;
using System.Collections.Generic;
using System.Linq;

namespace Phase4
{
    public class TopStudentsIntroducer
    {
        private readonly Reader _reader;
        private readonly AverageEngine _averageEngine;
        
        public TopStudentsIntroducer(Reader reader, AverageEngine averageEngine)
        {
            _reader = reader;
            _averageEngine = averageEngine;
        }

        public void processInfo( string _pathStudents, string _pathScores)
        {
            
            var students = _reader.ReadJson<Student>(_pathStudents);
            var studentsScores = _reader.ReadJson<StudentScore>(_pathScores);
            var studentsAverage = _averageEngine.CalculateAvg(students, studentsScores);
            PrintTopStudents(3,studentsAverage);
        }

        private void PrintTopStudents(int numberOfTopStudents, IEnumerable<StudentAverage> studentsAverage)
        {
            var topStudents = studentsAverage.Take(numberOfTopStudents);
            foreach (var topStudent in topStudents)
                Console.WriteLine(topStudent);
        }
        
    }
}