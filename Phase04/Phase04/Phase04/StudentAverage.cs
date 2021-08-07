namespace Phase4
{
    public class StudentAverage
    {
        private readonly Student _student;
        public readonly double AverageScore;

        public StudentAverage(Student student, double averageScore)
        {
            _student = student;
            AverageScore = averageScore;
        }

        public override string ToString()
        {
            return $"Name : {_student.FirstName} {_student.LastName} " +
                   $"With grade point average : {AverageScore}";
        }
    }
}