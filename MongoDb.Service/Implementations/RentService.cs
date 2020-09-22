using MongoDb.Data.Models;
using MongoDb.Service.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDb.Service.Implementations
{
    public class RentService : IRentService
    {
        private readonly Repository<Rent> _rentRepository;
        private readonly IMongoDbRepository<Rent> _mongoRent;
        public RentService()
        {
            _rentRepository = new Repository<Rent>();
            _mongoRent = new Repository<Rent>();
        }

        public void RentBook(Rent rent)
        {
            _rentRepository.Add("rent", rent);
        }
        public void ReturnBook(Rent rent)
        {
            _rentRepository.Update("rent", rent);
        }

        public List<Rent> GetRents()
        {
            return _mongoRent.GetAll("rent");
        }

        public Rent GetRent(string id)
        {
            return _mongoRent.Get("rent", id.ToString());
        }
    }
}
