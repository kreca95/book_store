using MongoDb.Data.Models;
using MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Service.Interfaces
{
    public interface IMongoDbRepository<T> where T : IEntityBase
    {
        T Get(string table, string id);
        List<T> GetAll(string table);

        void Add(string table, T resource);
        void Update(string table, T resource);
        void Delete(string table, T resource);
    }
}
