
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Infrastructure.Peristance.Entities;

namespace Todo.api
{
    public static class AppDependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection service, IConfiguration config)
        {

            var connectionString = config.GetConnectionString("DefaultConnection");
            // register AppDbContext as a service
            service.AddDbContext<AppDbContext>(options =>
               options.UseSqlite(connectionString));

            return service;
        }

    }
}
