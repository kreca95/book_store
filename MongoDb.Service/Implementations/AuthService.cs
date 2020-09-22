using MongoDb.Data;
using MongoDb.Data.Models;
using MongoDb.Service.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDb.Service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly Repository<User> _userRepository;
        private IMongoDatabase _context;

        public AuthService()
        {
            _userRepository = new Repository<User>();
            _context = new MongoDbContext().GetMBongoDatabase();
        }

        public User Login(string username, string password)
        {
            var user = _context.GetCollection<User>("user").Find(x => x.Email == username && x.Password == password).FirstOrDefault();
            //user.Role.Name = "Admin";
            return user;
        }
        public void Register(User user)
        {
            _userRepository.Add("user", user);
        }
    }
}
