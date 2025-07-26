using Application.Dtos.Address;
using Application.Dtos.Customer;
using Application.Services;
using Application.Services.Interface;
using Application.Shared.Mappers;
using Application.Shared.Mappers.Interface;
using Application.Validators.Address;
using Application.Validators.Customer;
using Domain.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationRegistration
{
    public static void AddValidators(this IServiceCollection svc)
    {
        svc.AddScoped<IValidator<CustomerInsert>, InsertCustomerValidator>();
        svc.AddScoped<IValidator<CustomerUpdate>, UpdateCustomerValidator>();

        svc.AddScoped<IValidator<AddressInsert>, InsertAddressValidator>();
        svc.AddScoped<IValidator<AddressUpdate>, UpdateAddressValidator>();
    }

    public static void AddServices(this IServiceCollection svc)
    {
        svc.AddScoped<IAddressService, AddressService>();
        svc.AddScoped<ICustomerService, CustomerService>();
    }
    
    public static void AddMappers(this IServiceCollection svc)
    {
        svc.AddScoped<IAddressMapper, AddressMapper>();
        svc.AddScoped<ICustomerMapper, CustomerMapper>();
    }
}