using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDb.Data.Models
{
    public class User:EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
