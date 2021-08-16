﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SQLHandler
{
    public class Document
    {
        [Key]
        public int  DocumentId { get; set; }
        public string DocName { get; set; }
        public string DocContents { get; set; }

        public List<Word> wordsCollection { get; set; } = new List<Word>();

        public Document()
        {
        }

        public Document(string docName, string docContents)
        {
            DocName = docName;
            DocContents = docContents;
        }
    }
    
}