using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SQLHandler
{
    public class Word
    {
        [Key]
        public int id { get; set; }
        public string Content{ get; set; }
        public List<Document> DocsCollection { get; set; }
        
    }
    
}