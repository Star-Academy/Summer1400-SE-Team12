using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SQLHandler
{
    public class Word
    {
        [Key]
        public string eachWord{ get; set; }
        public ISet<Document> DocsCollection { get; set; }

        public Word()
        {
        }

        public Word(string eachWord, ISet<Document> docsCollection)
        {
            this.eachWord = eachWord;
            DocsCollection = docsCollection;
        }
    }
    
}