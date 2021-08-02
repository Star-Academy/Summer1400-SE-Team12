using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Phase4
{
    public class Reader
    {
        private List<Student> studentsList = new List<Student>();
        private List<StudentScore> point = new List<StudentScore>();
        public List<Student> Readstudents(string path)
        {
            StreamReader r = new StreamReader(path);
            string json = r.ReadToEnd();
            studentsList = JsonConvert.DeserializeObject<List<Student>>(json);
            
            return studentsList;
            
        }
        public List<StudentScore> ReadPoint(string path)
        {
            StreamReader r = new StreamReader(path);
            string json = r.ReadToEnd();
            point = JsonConvert.DeserializeObject<List<StudentScore>>(json);
            
            return point;
        }
       
    }
}