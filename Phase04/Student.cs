namespace DefaultNamespace
{
    
   
        public class Student // dorost kon
        {

            public int StudentNumber { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public override string ToString()
            {
                return $"FirstName : {FirstName} " +
                       $"->" +
                       $" LastName : {LastName} ";
            }
        
        
        }
    }
    
    
