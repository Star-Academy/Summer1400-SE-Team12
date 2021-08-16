using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SQLHandler;

namespace TestEFCorePhase08
{
    public static class ContextFactory
    {
        private static InvertedIndexContext _invertedIndexContext;

        public static InvertedIndexContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<InvertedIndexContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _invertedIndexContext = new InvertedIndexContext(options);
            _invertedIndexContext.Database.EnsureDeleted();
            _invertedIndexContext.Database.EnsureCreated();
            FillContextWithExamples();
            return _invertedIndexContext;
        }

        private static void FillContextWithExamples()
        {
            var doc1 = new Document("doc1", "hello im zahra");
            doc1.wordsCollection.Add(new Word() {Content = "zahra"});
            var doc2 = new Document("doc2", "hello im neda");
            doc2.wordsCollection.Add(new Word() {Content = "neda"});
            var doc3 = new Document("doc3", "hello im ali , bye !");
            doc3.wordsCollection.Add(new Word() {Content = "ali"});
            var doc4 = new Document("doc4", "bye everyone");
            doc4.wordsCollection.Add(new Word() {Content = "everyone"});
            var doc5 = new Document("doc5", "bye bye");
            var word1 = new Word() {Content = "hello", DocsCollection = new List<Document>() {doc1, doc2, doc3}};
            var word2 = new Word() {Content = "bye", DocsCollection = new List<Document>() {doc3, doc4, doc5}};
            
            _invertedIndexContext.DocumentsDbContext.AddRange(doc1, doc2, doc3, doc4, doc5);
            _invertedIndexContext.WordsDbContext.AddRange(word1, word2);
            _invertedIndexContext.SaveChanges();
        }
    }
}