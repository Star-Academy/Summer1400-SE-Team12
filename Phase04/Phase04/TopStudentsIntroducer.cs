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

        public IEnumerable<StudentAverage> GetTopStudents(int numberOfTopStudents, string _pathStudents, string _pathScores)
        {
            
            var students = _reader.DeserializeReadJson<Student>(_pathStudents);
            var studentsScores = _reader.DeserializeReadJson<StudentScore>(_pathScores);
            var studentsAverage = _averageEngine.CalculateAvg(students, studentsScores);
            return studentsAverage.Take(numberOfTopStudents);
        }

    }
}