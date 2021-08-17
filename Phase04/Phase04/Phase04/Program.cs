namespace Phase4
{
    class Program
    {
        private static string _pathStudents = @"JsonFiles\Students.json";
        private static string _pathScores = @"JsonFiles\Scores.json";
        
        static void Main(string[] args)
        {
            var reader = new Reader();
            var information = new AverageEngine();
            
            var students = reader.ReadJson<Student>(_pathStudents);
            var studentsScores = reader.ReadJson<StudentScore>(_pathScores);
            var studentsAverage = information.calculateAvg(students, studentsScores);
            information.PrintTopStudents(3,studentsAverage);

        }
        
    }

}
