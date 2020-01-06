using MongoDb.Data.Models;
using MongoDb.Models;
using MongoDb.Service.Implementations;
using MongoDb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MongoDb.Controllers
{
    [RoutePrefix("rent")]
    public class RentController : ApiController
    {
        private readonly IRentService _rentService;

        public RentController()
        {
            _rentService = new RentService();
        }

        [HttpPost]
        [Route("action")]
        public IHttpActionResult Action([FromBody] BookActionRequest bookActionRequest)
        {
            Rent rent = new Rent();
            rent.Id = bookActionRequest.Id;
            rent.BookId = bookActionRequest.BookId;
            rent.UserId = bookActionRequest.UserId;
            if (bookActionRequest.Action=="return")
            {
                rent.Returned = true;
                rent.DateReturned = DateTime.Now;
                _rentService.ReturnBook(rent);
            }
            else if (bookActionRequest.Action=="rent")
            {
                rent.DateRented = DateTime.Now;
                rent.Returned = false;
                _rentService.RentBook(rent);
            }
            
            return Ok();
        }
    }
}
