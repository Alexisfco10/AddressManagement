using Application.Dtos.Customer;
using Domain.Models;

namespace Application.Services.Interface;

public interface ICustomerService : IService<Customer, CustomerDto, CustomerInsert, CustomerUpdate>
{
    
}