using System;
using System.Linq;

namespace Phase4
{
    public class TopStudents
    {
        private Reader _reader;
        private AverageEngine _averageEngine;
        
        public TopStudents(Reader reader, AverageEngine averageEngine)
        {
            _reader = reader;
            _averageEngine = averageEngine;
        }

        public void processInfo( string _pathStudents, string _pathScores)
        {
            
            var students = _reader.ReadJson<Student>(_pathStudents);
            var studentsScores = _reader.ReadJson<StudentScore>(_pathScores);
            var studentsAverage = _averageEngine.calculateAvg(students, studentsScores);
            PrintTopStudents(3,studentsAverage);
        }

        private void PrintTopStudents(int numberOfTopStudents, IOrderedEnumerable<dynamic> studentsAverage)
        {
            var topStudents = studentsAverage.Take(numberOfTopStudents);
            foreach (var topStudent in topStudents)
                Console.WriteLine($"Name : {topStudent.Student.FirstName} {topStudent.Student.LastName} " +
                                  $"With grade point average : {topStudent.Average}");
        }
        
    }
}