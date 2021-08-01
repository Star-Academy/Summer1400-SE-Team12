
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    namespace DefaultNamespace
    {

        public class Reader
        {
            private List<Student> studentsList = new List<Student>();
            private List<StudentScore> point = new List<StudentScore>();
            public List<Student> ReadJson(string path)
            {

                StreamReader r = new StreamReader(path);
            
                string json = r.ReadToEnd();
                studentsList = JsonConvert.DeserializeObject<List<Student>>(json);

                foreach (var i in studentsList)
                {
                    Console.WriteLine(i);

                }

                //var studentTOPoint = studentsList.Select(s => point.Where(p => p.StudentNumber == s.StudentNumber));


                return studentsList;
            }
     
        
        
        
        
        
        
        
        
        }
    }
    
    
