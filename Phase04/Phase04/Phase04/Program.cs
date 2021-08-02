namespace Phase4
{
    class Program
    {
        private static string _pathNames = @"JsonFiles\Students.json";
        private static string _pathPoints = @"JsonFiles\Scores.json";
        
        static void Main(string[] args)
        {
            var reader = new Reader();
            var information = new AverageEngine();
            
            var students = reader.ReadJson<Student>(_pathNames);
            var studentsScores = reader.ReadJson<StudentScore>(_pathPoints);
            var studentsAverage = information.calculateAvg(students, studentsScores);
            information.PrintTopStudents(3,studentsAverage);

        }
        
    }

}
