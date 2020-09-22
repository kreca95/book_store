using MongoDb.Data.Models;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDb.Models
{
    public class Book : EntityBase
    {
        public string Name { get; set; }
        public DateTime Published { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }

    }
}