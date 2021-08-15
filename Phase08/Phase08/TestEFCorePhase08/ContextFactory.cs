using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SQLHandler;

namespace TestEFCorePhase08
{
    public static class ContextFactory
    {
        public static InvertedIndexContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<InvertedIndexContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
             var invertedIndexContext = new InvertedIndexContext(options);
             invertedIndexContext.Database.EnsureDeleted();
            invertedIndexContext.Database.EnsureCreated();

            var doc1 = new Document("doc1", "hello im zahra");
            doc1.wordsCollection.Add(new Word() {eachWord = "zahra"});
            var doc2 = new Document("doc2", "hello im neda");
            doc2.wordsCollection.Add(new Word() {eachWord = "neda"});
            var doc3 = new Document("doc3", "hello im mmd, bye !");
            doc3.wordsCollection.Add(new Word() {eachWord = "mmd"});
            var doc4 = new Document("doc4", "bye everyone");
            doc4.wordsCollection.Add(new Word() {eachWord = "everyone"});
            var doc5 = new Document("doc5", "bye bye");
            var word1 = new Word() {eachWord = "hello", DocsCollection = new HashSet<Document>() {doc1, doc2, doc3}};
            var word2 = new Word() {eachWord = "bye", DocsCollection = new HashSet<Document>() {doc3, doc4, doc5}};


            invertedIndexContext.DocumentsDbContext.AddRange(doc1, doc2, doc3, doc4, doc5);
            invertedIndexContext.WordsDbContext.AddRange(word1, word2);
            invertedIndexContext.SaveChanges();
            return invertedIndexContext;
        }
    }
}