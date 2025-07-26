using System.Linq.Expressions;
using Application.Dtos.Customer;
using Application.Repository;
using Application.Services.Interface;
using Application.Shared.Mappers.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class CustomerService(ICustomerRepository repository, ICustomerMapper mapper) 
    : BaseService<Customer, CustomerDto, CustomerInsert, CustomerUpdate>(repository, mapper), ICustomerService
{
    private readonly IRepository<Customer> _repository = repository;
    private readonly IMapper<Customer, CustomerDto, CustomerInsert, CustomerUpdate> _mapper = mapper;

    public override async Task<CustomerDto?> Get(long id)
    {
        var result = await _repository.Get(id, c => 
            c.Include(customer => customer.Addresses));
        
        return result == null ? null : _mapper.ToDto(result);
    }

    public override async Task<IEnumerable<CustomerDto>> Get()
    {
        var result = await _repository.GetAll(c => 
            c.Include(customer => customer.Addresses));

        return result.Select(c => _mapper.ToDto(c));
    }

    public override async Task<IEnumerable<CustomerDto>> Get(Expression<Func<Customer, bool>> predicate)
    {
        var result = await _repository.Search(predicate, c => 
            c.Include(customer => customer.Addresses));

        return result.Select(c => _mapper.ToDto(c));
    }

    public override async Task<CustomerDto> Add(CustomerInsert addRequest)
    {
        var customer = _mapper.ToModel(addRequest);
        await _repository.Add(customer);
        await _repository.Save();
        
        return _mapper.ToDto(customer);
    }
    
    public override async Task<CustomerDto?> Update(CustomerUpdate updateRequest)
    {
        var customer = await _repository.Get(updateRequest.Id);
        if (customer == null)
            return null;
        
        customer = _mapper.ToModel(customer, updateRequest);
        _repository.Update(customer);
        await _repository.Save();
        return _mapper.ToDto(customer);
    }
}