using System;
using System.Collections.Generic;
using System.Linq;

namespace Phase4
{
    public class Information
    { 
        public void ShowInfo()
        {
            var pathNames = @"C:\Users\ts\RiderProjects\Phase4\Phase4\Names.json";
            var pathPoints = @"C:\Users\ts\RiderProjects\Phase4\Phase4\Points.json";
            var studentsLists = new List<Student>();
            List<StudentScore> pointsLists = new List<StudentScore>();
            var r = new Reader();
            
            studentsLists = r.Readstudents(pathNames);
            pointsLists = r.ReadPoint(pathPoints);

            var list2 = studentsLists.Select(s => new
            {
                Student = s,
                Average = pointsLists.Where(p => p.StudentNumber == s.StudentNumber).Select(x => x.Score).Average()
            }).OrderByDescending(x => x.Average);

            var list3 = list2.Take(3);
            foreach (var i in list3)
            {
                Console.WriteLine($"Name : {i.Student.FirstName} {i.Student.LastName} With grade point average : {i.Average}");
            }
                        
        }

    }
}