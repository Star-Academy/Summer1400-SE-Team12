namespace Phase4
{
    public class TopStudents
    {
        
        public void PrintTopStudents(int numberOfTopStudents, IOrderedEnumerable<dynamic> studentsAverage)
        {
            var topStudents = studentsAverage.Take(numberOfTopStudents);
            foreach (var topStudent in topStudents)
                Console.WriteLine($"Name : {topStudent.Student.FirstName} {topStudent.Student.LastName} " +
                                  $"With grade point average : {topStudent.Average}");
        }

        public void g()
        {
            
            var students = reader.ReadJson<Student>(_pathStudents);
            var studentsScores = reader.ReadJson<StudentScore>(_pathScores);
            var studentsAverage = averageEngine.calculateAvg(students, studentsScores);
            averageEngine.PrintTopStudents(3,studentsAverage);
            
        }
        
        
        
        
    }
}