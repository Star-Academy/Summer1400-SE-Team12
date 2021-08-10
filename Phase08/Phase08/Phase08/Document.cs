using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phase08
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public string DocName { get; set; }
        public string DocContents { get; set; }
        
        [ForeignKey("eachWord")]
        public string eachWord{ get; set; }

        public ICollection<Word> wordsCollection { get; set; }
    }
    
}