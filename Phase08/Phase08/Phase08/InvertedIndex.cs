﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SQLHandler;

namespace Phase08
{
    public class InvertedIndex : IInvertedIndex
    {
        private readonly IInvertedIndexWrapper _invertedIndexWrapper;

        public InvertedIndex(IInvertedIndexWrapper invertedIndexWrapper)
        {
            _invertedIndexWrapper = invertedIndexWrapper;
        }

        public void BuildInvertedIndex(Dictionary<string, string> docMapToContent)
        {
            foreach (var (docName, docContent) in docMapToContent)
            {
                var words = SplitDocumentsWords(docContent);
                var document = new Document(docName, docContent);
                _invertedIndexWrapper.AddDocumentWords(document, words);
            }
        }

        private string[] SplitDocumentsWords(string docContent)
        {
            return Regex.Split(docContent, "[\\W]+");
        }

        
    }
}