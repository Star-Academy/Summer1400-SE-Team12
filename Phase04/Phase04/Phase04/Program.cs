namespace Phase4
{
    class Program
    {
        private static string _pathNames = @"D:\programming\code-star\phase04\Summer1400-SE-Team12\Phase04\Phase04\Phase04\Names.json";
        private static string _pathPoints = @"D:\programming\code-star\phase04\Summer1400-SE-Team12\Phase04\Phase04\Phase04\Points.json";
        
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
