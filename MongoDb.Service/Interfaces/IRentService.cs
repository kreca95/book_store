using System;
using System.Collections.Generic;
using System.Text;
using MongoDb.Data.Models;
using MongoDB.Bson;

namespace MongoDb.Service.Interfaces
{
    public interface IRentService
    {
        void RentBook(Rent rent);
        void ReturnBook(Rent rent);
        List<Rent> GetRents();
        Rent GetRent(string id);
    }
}
