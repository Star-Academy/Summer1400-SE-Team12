using System;
using System.Collections.Generic;
using System.IO;

namespace Phase05
{
    public class FileReader
    {
        public Dictionary<string, string> ReadFile(string path)
        {
            var documents = new Dictionary<string, string>();
            
            foreach (string txtName in Directory.GetFiles(path))
            {
                using (var streamReader = new StreamReader(txtName))
                {
                    documents.Add(txtName.Replace("C:\\Users\\ts\\Desktop\\EnglishData\\",""),streamReader.ReadToEnd());
                    
                }
            }
            return documents;

        }
        
        
        
        
    }
}