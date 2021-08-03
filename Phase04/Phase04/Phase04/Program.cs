namespace Phase4
{
    class Program
    {
        private const string PathStudents = @"JsonFiles\Students.json";
        private const string PathScores = @"JsonFiles\Scores.json";

        static void Main(string[] args)
        {
            var reader = new Reader();
            var averageEngine = new AverageEngine();
            var topStudents = new TopStudentsIntroducer(reader, averageEngine);
            topStudents.processInfo(PathStudents, PathScores);
        }
        
    }

}
