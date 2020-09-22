using MongoDb.Data;
using MongoDb.Data.Models;
using MongoDb.Service.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Service.Implementations
{
    public class Repository<T> : IMongoDbRepository<T> where T : IEntityBase
    {
        private IMongoDatabase _context = new MongoDbContext().GetMBongoDatabase();

        public void Add(string table, T resource)
        {

            _context.GetCollection<T>(table).InsertOne(resource);
        }

        public void Delete(string table, T resource)
        {
            _context.GetCollection<T>(table).DeleteOne(Builders<T>.Filter.Eq(s => s.Id, resource.Id));
        }

        public T Get(string table, string id)
        {
            var objectId = new ObjectId(id);

            var item = _context.GetCollection<T>(table).Find<T>(Builders<T>.Filter.Eq(x => x.Id, id));
            return item.FirstOrDefault();
        }

        public List<T> GetAll(string table)
        {
            var items = _context.GetCollection<T>(table).Find(Builders<T>.Filter.Empty).ToList();
            return items;
        }

        public void Update(string table, T resource)
        {
            var a = _context.GetCollection<T>(table).ReplaceOne(b => b.Id == resource.Id, resource);
        }
    }
}
