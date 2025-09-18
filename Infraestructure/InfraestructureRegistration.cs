using Application.Repository;
using Application.UnitOfWork;
using Infraestructure.Context;
using Infraestructure.Repository;
using Infraestructure.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure;

public static class ServiceRegistration
{
    public static void AddContext(this IServiceCollection svc, IConfiguration config)
    {
        svc.AddDbContext<AddressManagementDbContext>(c => c.UseSqlServer(
            config.GetConnectionString("AddressManagementConnection")));
    }
    
    public static void AddRepositories(this IServiceCollection svc)
    {
        svc.AddScoped<IAddressRepository, AddressRepository>();
        svc.AddScoped<ICustomerRepository, CustomerRepository>();
    }

    public static void AddUnitOfWork(this IServiceCollection svc)
    {
        svc.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}