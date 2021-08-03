namespace Phase4
{
    public class StudentAverage
    {
        public readonly Student Student;
        public readonly double AverageScore;

        public StudentAverage(Student student, double averageScore)
        {
            this.Student = student;
            this.AverageScore = averageScore;
        }

        public override string ToString()
        {
            return $"Name : {this.Student.FirstName} {this.Student.LastName} " +
                   $"With grade point average : {this.AverageScore}";
        }
    }
}