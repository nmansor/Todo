using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.DomainEntities;
using Todo.Infrastructure.Persistence.Entities;

namespace Todo.Infrastructure.Mapper
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDomain>().ReverseMap();
        }

        //protected internal UserMapping(string profileName) : base(profileName)
        //{
        //}
    }
}
