﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Phase05
{
    public class FileReader
    {
        public Dictionary<string, string> ReadFile(string path)
        {
            var documents = new Dictionary<string, string>();
            
            foreach (string filePath in Directory.GetFiles(path))
                documents.Add(Path.GetFileName(filePath), File.ReadAllText(filePath));

            return documents;
        }
    }
}