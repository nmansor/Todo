
using Todo.Application.Dtos.Requests;
using Todo.Domain.DomainEntities;
namespace Todo.Application.interfaces
{
    public interface IUserService
    {
        Task<UserDomain> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDomain>> GetAllUserAsync();
        Task<bool> AddAsync(CreateUserDto  user);
        Task<int> UpdateUser(int id, UserDomain user);
    }
}
