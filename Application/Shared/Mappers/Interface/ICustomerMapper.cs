using Application.Dtos.Customer;
using Domain.Models;

namespace Application.Shared.Mappers.Interface;

public interface ICustomerMapper : IMapper<Customer, CustomerDto, CustomerInsert, CustomerUpdate> 
{
    
}