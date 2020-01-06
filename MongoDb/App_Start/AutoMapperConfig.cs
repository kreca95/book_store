using AutoMapper;
using MongoDb.Models;
using MongoDb.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDb.App_Start
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            Mapper.CreateMap<Book, AddBookRequest>();
            Mapper.CreateMap<AddBookRequest, Book>();

        }
    }
}