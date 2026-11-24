
using Microsoft.EntityFrameworkCore;

using Todo.Infrastructure.Persistence.Entities;

namespace Todo.api
{
    public static class AppDependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection service, IConfiguration config)
        {

            var connectionString = config.GetConnectionString("DefaultConnection");
            // register AppDbContext as a service
            service.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(connectionString));

            return service;
        }

    }
}
