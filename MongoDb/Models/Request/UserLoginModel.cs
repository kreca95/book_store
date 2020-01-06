using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDb.Models.Request
{
    public class UserLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}