using MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDb.Data.Models
{
    public class Rent:EntityBase
    {

        public bool Returned { get; set; }
        public string BookId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime DateReturned { get; set; }

    }
}
