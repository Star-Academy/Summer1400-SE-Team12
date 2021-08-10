using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phase08
{
    public class Word
    {
        public Word(string eachWord, ISet<Document> docsCollection)
        {
            this.eachWord = eachWord;
            DocsCollection = docsCollection;
        }

        [Key]
        public int Id { get; set; }
        
        [Key]
        public string eachWord{ get; set; }
        
        public ISet<Document> DocsCollection { get; set; }

    }
    
}