using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.DomainEntities;

namespace Todo.Domain.RepositoryInterface
{
    public interface IUserRepository : IGenericRepositroy<UserDomain> {
       public Task<UserDomain> GetByEmailAsync(string email);
    }

}
