using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Phase4
{
    public class Reader
    {
        public List<T> ReadJson<T>(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            string json = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

    }
}
