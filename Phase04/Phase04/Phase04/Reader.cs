using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Phase4
{
    public class Reader
    {
        public List<T> DeserializeReadJson<T>(string path)
        {
            var deserializedJson = new List<T>();
            try
            {
                var json = File.ReadAllText(path);
                deserializedJson = JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }
            return deserializedJson;
        }
    }
}