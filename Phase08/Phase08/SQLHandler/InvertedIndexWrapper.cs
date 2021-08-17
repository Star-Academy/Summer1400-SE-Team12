﻿using System.Collections.Generic;

namespace SQLHandler
{
    public class InvertedIndexWrapper : IInvertedIndexWrapper
    {
        private InvertedIndexContext _invertedIndexContext;

        public InvertedIndexWrapper(InvertedIndexContext invertedIndexContext)
        {
            _invertedIndexContext = invertedIndexContext;
        }

        public IEnumerable<string> GetDocumentsContainQuery(string query)
        {
            return _invertedIndexContext.GetDocumentsContainQuery(query);
        }

        public bool IsDataBaseInitialized()
        {
            return _invertedIndexContext.IsDataBaseInitialized();
        }

        public void AddDocumentWords(Document document, IEnumerable<string> docWords)
        {
            _invertedIndexContext.AddDocumentWords(document,docWords);
        }

        public void AddNewWord(string wordContent)
        {
            _invertedIndexContext.AddNewWord(wordContent);
            _invertedIndexContext.SaveChanges();
        }
    }
}