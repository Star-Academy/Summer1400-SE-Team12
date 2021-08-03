using System;
using System.Collections.Generic;
using System.Linq;

namespace Phase4
{
    public class AverageEngine
    {
        public dynamic calculateAvg(List<Student> students, List<StudentScore> studentScores)
        {
            var studentAverage = students.Select(s => new
            {
                Student = s,
                Average = studentScores.Where(p => p.StudentNumber == s.StudentNumber).Select(x => x.Score).Average()
            }).OrderByDescending(x => x.Average);

            return studentAverage;
        }
        
    }
}