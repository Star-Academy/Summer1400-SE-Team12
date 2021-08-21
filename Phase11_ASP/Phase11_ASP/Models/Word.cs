using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Phase11_ASP.Models
{
    public class Word
    {
        [Key]
        public int id { get; set; }
        public string Content{ get; set; }
        public List<Document> DocsCollection { get; set; }
        
    }
    
}