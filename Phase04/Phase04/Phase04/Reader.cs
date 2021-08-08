using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Phase4
{
    public class Reader
    {
        public List<T> ReadJson<T>(string path)
        {
            try
            {
                var streamReader = new StreamReader(path);
                var json = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

    }
}
