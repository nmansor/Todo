using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.DomainEntities;
using Todo.Domain.RepositoryInterface;
using Todo.Infrastructure.Persistence.Entities;
using Todo.Infrastructure.RepositoryInterface;

namespace Todo.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<UserDomain,User>, IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(AppDbContext context, IMapper mapper):base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDomain> GetByEmailAsync(
            string emailAddress)
        {

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == emailAddress);

            return _mapper.Map<UserDomain>(user);
        }
    }
}
