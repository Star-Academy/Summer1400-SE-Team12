namespace Phase4
{
    public class StudentScore
    {
        
        public int StudentNumber { get; set; }
        public string Lesson { get; set; }
        public double Score { get; set; }
 
        public override string ToString()
        {
            return $"StudentNumber : {StudentNumber} " +
                   "->" +
                   $"Lesson : {Lesson} "+
                   "->"+
                   $" Score : {Score} ";
        }
    }
}