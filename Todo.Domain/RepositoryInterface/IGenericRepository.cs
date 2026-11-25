using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.RepositoryInterface
{
    public interface IGenericRepositroy<TDomain> where TDomain: class
    {
      public  Task<TDomain> GetByIdAsync(object id);
      public  Task<IEnumerable<TDomain>> GetAllAsync();
      public  Task AddAsync(TDomain domain);
      public  Task<int> CommitAsync();


    }
}
