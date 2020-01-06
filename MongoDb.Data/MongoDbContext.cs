using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDb.Data
{
    public class MongoDbContext
    {
        private IMongoClient _client;
        private IMongoDatabase _database;

        public MongoDbContext()
        {
            _client = new MongoClient("mongodb://localhost");
            _database = _client.GetDatabase("BookStore");
        }

        public IMongoDatabase GetMBongoDatabase()
        {
            return _database;
        }
    }
}
