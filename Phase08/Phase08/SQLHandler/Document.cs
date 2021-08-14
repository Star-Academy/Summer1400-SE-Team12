using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SQLHandler
{
    public class Document
    {
        [Key]
        public string DocName { get; set; }
        public string DocContents { get; set; }

        public ISet<Word> wordsCollection { get; set; }

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