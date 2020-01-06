using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Service.Interfaces
{
    public interface IBookService
    {
        bool IsAvailable(string id);
        bool ReturnBook(string id);
        bool RentBook(string id);
    }
}
