using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phase08
{
    public class Word
    {
        [Key]
        public int Id { get; set; }
        
        public string eachWord{ get; set; }
        
        public ISet<Document> DocsCollection { get; set; }

    }
    
}