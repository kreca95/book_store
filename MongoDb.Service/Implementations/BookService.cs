using MongoDb.Data;
using MongoDb.Models;
using MongoDb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Service.Implementations
{
    public class BookService : IBookService
    {
        private readonly IMongoDbRepository<Book> _bookRepository;

        public BookService()
        {
            _bookRepository = new Repository<Book>();
        }

        public  bool IsAvailable(string id)
        {
            return  _bookRepository.Get("book", id).Quantity>0;
        }

        public  bool RentBook(string id)
        {
            bool isAvailable = IsAvailable(id);
            if (isAvailable)
            {
                Book book = _bookRepository.Get("book", id);
                book.Quantity--;
                 _bookRepository.Update("book", book);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReturnBook(string id)
        {
            Book book = _bookRepository.Get("book", id);
            book.Quantity++;
            _bookRepository.Update("book", book);
            return true;
        }
    }
}
