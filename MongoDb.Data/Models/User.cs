using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDb.Data.Models
{
    public class User:EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public string RoleId { get; set; }

        public Role Role { get; set; }



        public User()
        {
            Role = new Role();
        }
    }
}
