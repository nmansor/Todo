using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Application.Dtos.Requests;
using Todo.Application.interfaces;
using Todo.Domain.DomainEntities;
using Todo.Domain.RepositoryInterface;
using BCrypt.Net;
using Todo.Application.Dtos.Responses;
namespace Todo.Application.services
{
    public class UserService(IUserRepository repo, IMapper mapper, IPasswordHassher hasher) : IUserService
    {
      
        public async Task<bool> AddAsync(CreateUserDto  user)
        {
            var userDomain = mapper.Map<UserDomain>(user);
            userDomain.PasswordHash = hasher.Hash(userDomain.PasswordHash);
          
            await repo.AddAsync(userDomain);
            var response = await repo.CommitAsync();
            return response > 0;
        }

       

        public Task<UserDomain> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateUser(int id, UserDomain user)
        {
            throw new NotImplementedException();
        }


        Task<IEnumerable<UserDomain>> IUserService.GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        Task<UserDomain> IUserService.GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
