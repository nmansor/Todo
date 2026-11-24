

using Todo.Infrastructure.Persistence.Entities;
using Todo.Infrastructure.RepositoryInterface;
using Todo.Domain.RepositoryInterface;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
namespace Todo.Infrastructure.RepositoryInterface
{
    public class GenericRepository<TDomain, TEntity> : IGenericRepositroy<TDomain>
        where TDomain:class
        where TEntity:class
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
       public GenericRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(TDomain domain)
        {
            var entity = _mapper.Map<TEntity>(domain);

             await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TDomain>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ProjectTo<TDomain>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<TDomain> GetByIdAsync(object id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id); // id must be a primary key

            return entity == null ? null : _mapper.Map<TDomain>(entity);

        }
    }
}
