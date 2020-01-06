using MongoDb.Data.Models;
using MongoDb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDb.Service.Implementations
{
    public class RentService : IRentService
    {
        private readonly Repository<Rent> _rentRepository;

        public RentService()
        {
            _rentRepository = new Repository<Rent>();
        }

        public void RentBook(Rent rent)
        {
            _rentRepository.Add("rent", rent);
        }
        public void ReturnBook(Rent rent)
        {
            _rentRepository.Update("rent", rent);
        }
    }
}
