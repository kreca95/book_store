using MongoDb.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDb.Service.Interfaces
{
    public interface IAuthService
    {
        User Login(string username,string password);
    }
}
