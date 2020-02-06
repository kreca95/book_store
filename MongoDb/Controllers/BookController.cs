using AutoMapper;
using MongoDb.Models;
using MongoDb.Models.Request;
using MongoDb.Models.Tables;
using MongoDb.Service.Implementations;
using MongoDb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MongoDb.Controllers
{
    [Route("book")]
    public class BookController : ApiController
    {
        private readonly IMongoDbRepository<Book> _bookRepository = new Repository<Book>();
        private readonly IBookService _bookService = new BookService();
        [HttpPost]
        [Authorize]
        public  IHttpActionResult Add(AddBookRequest book)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var addbook = Mapper.Map<Book>(book);
             _bookRepository.Add(DatabaseTableNames.Books, addbook);
            return Ok(book);
        }
        [HttpGet]
        public  IHttpActionResult GetAllBooks()
        {
            var items =  _bookRepository.GetAll(DatabaseTableNames.Books);
            return Ok(items);
        }

        [HttpGet]
        [Route("book/{id}")]
        public  IHttpActionResult GetBook(string id)
        {
            var book =  _bookRepository.Get(DatabaseTableNames.Books, id);
            return Ok(book);
        }
        [HttpDelete]
        [Route("book/{id}")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteBook(string id)
        {
            _bookRepository.Delete(DatabaseTableNames.Books,  _bookRepository.Get(DatabaseTableNames.Books, id.ToString()));
            return Ok();

        }

        [HttpPut]
        [Route("book/{id}")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult UpdateBook(string id,[FromBody] Book book)
        {
            if (id==book.Id)
            {
                 _bookRepository.Update(DatabaseTableNames.Books, book);
                return Ok();
            }
            return BadRequest("Id-s do not match");
        }
    } 

}