using System;
using System.Collections.Generic;
using System.Text;
using MongoDb.Data.Models;

namespace MongoDb.Service.Interfaces
{
    public interface IRentService
    {
        void RentBook(Rent rent);
        void ReturnBook(Rent rent);
    }
}
