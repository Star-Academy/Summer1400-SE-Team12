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
                stu => stu.StudentNumber,
                scr => scr.StudentNumber,
                (stu, scr) => 
                    new StudentAverage(stu, scr.Select(s => s.Score).Average())).
                OrderByDescending(s => s.averageScore);

            return studentAverage;
        }
    }
}