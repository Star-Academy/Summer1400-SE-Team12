using System;
using System.Collections.Generic;
using System.Linq;

namespace Phase4
{
    public class AverageEngine
    {
        public IEnumerable<StudentAverage> CalculateAvg(IEnumerable<Student> students, IEnumerable<StudentScore> studentScores)
        {
            var studentAverage = students.GroupJoin(studentScores,
                s => s.StudentNumber,
                scr => scr.StudentNumber,
                (s, scr) => new
                    StudentAverage(s, scr.Select(x => x.Score).Average())).
                OrderByDescending(x => x.AverageScore);

            return studentAverage;
        }
    }
}