﻿using System.Collections.Generic;
using Castle.Core.Internal;
using SQLHandler;

namespace Phase08
{
    public class DataHandler : IDataHandler
    {
        private readonly IFileReader _fileReader;
        private readonly IInvertedIndex _invertedIndex;
        private readonly InvertedIndexContext _invertedIndexContext;

        public DataHandler(IFileReader fileReader, IInvertedIndex invertedIndex,
            InvertedIndexContext invertedIndexContext)
        {
            _fileReader = fileReader;
            _invertedIndex = invertedIndex;
            _invertedIndexContext = invertedIndexContext;
        }

        public void InitializeDataBase(string folderPath)
        {
            // if (_invertedIndexContext.DocumentsDbContext.IsNullOrEmpty() &&
            //     _invertedIndexContext.WordsDbContext.IsNullOrEmpty())
            // {
                _fileReader.ReadFile(folderPath);
                _invertedIndexContext.SaveChanges();
                var documents = new HashSet<Document>(_invertedIndexContext.DocumentsDbContext);
                _invertedIndex.BuildInvertedIndex(documents);
            // }
        }
    }
}