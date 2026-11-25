using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Todo.Infrastructure.Persistence.Entities;
using Todo.Application.interfaces;
using Todo.Application.services;
using Todo.Domain.RepositoryInterface;
using Todo.Application;
using Todo.Infrastructure.Repositories;
namespace Todo.Infrastructure
{
    //public static class AddDependencyInjection
    //{

    //    public static IServiceCollection  AddInfrastructureLayerDependency(this IServiceCollection service, IConfiguration config)
    //    {
    //        var connectionStr = config.GetConnectionString("DefaultConnection");
    //        if (string.IsNullOrWhiteSpace(connectionStr))
    //        {
    //            throw new Exception("Connection string is not found");
    //        }
    //        service.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionStr));

 
    //       //register it only for infrastructure layer classes
    //        service.AddAutoMapper(cfg => { }, typeof(InfraAssemblyMarker).Assembly);

    //        service.AddScoped<IUserRepository, UserRepository>();
            
    //        return service;
    //    }

    //    public static IServiceCollection AddApplicationLayerDependency(this IServiceCollection services)
    //    {
    //        services.AddScoped<IUserService, UserService>();

    //        //register it only for Application layer classes
    //        services.AddAutoMapper(cfg => { }, typeof(ApplicationLayerMarker).Assembly);

    //        return services;
    //    }
    //}
}
