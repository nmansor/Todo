
using Microsoft.EntityFrameworkCore;
using Todo.Application;
using Todo.Application.interfaces;
using Todo.Application.services;
using Todo.Domain.RepositoryInterface;
using Todo.Infrastructure;
using Todo.Infrastructure.Persistence.Entities;
using Todo.Infrastructure.Repositories;

namespace Todo.api
{
    public static class AppDependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayerDependency(this IServiceCollection service, IConfiguration config)
        {

            var connectionStr = config.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionStr))
            {
                throw new Exception("Connection string is not found");
            }
            service.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionStr));


            //register it only for infrastructure layer classes
            service.AddAutoMapper(cfg => { }, typeof(InfraAssemblyMarker).Assembly);

            service.AddScoped<IUserRepository, UserRepository>();

            return service;
        }


        public static IServiceCollection AddApplicationLayerDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            //register it only for Application layer classes
            services.AddAutoMapper(cfg => { }, typeof(ApplicationLayerMarker).Assembly);

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPasswordHassher, PasswordHasher>();

            return services;
        }

    }
}
