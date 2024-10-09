using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Infrastructure.Persistence.Concrete;
using EventManagementApi.Infrastructure.Persistence.DataAccess;
using EventManagementApi.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace EventManagementApi.Infrastructure.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<EventAppDB>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.Scan(scan => scan
             .FromAssembliesOf(typeof(IRepository<>))
             .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
             .AsImplementedInterfaces()
             .WithScopedLifetime());

        services.Scan(scan => scan
            .FromAssembliesOf(typeof(Repository<>))
            .AddClasses(classes => classes.AssignableTo(typeof(Repository<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddScoped<IClaimManager, ClaimManager>();
        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<IEmailManager, EmailManager>();
    }
}
