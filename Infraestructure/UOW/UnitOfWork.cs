using Application.Repository;
using Application.UnitOfWork;
using Domain.Models;
using Infraestructure.Context;
using Infraestructure.Repository;

namespace Infraestructure.UOW;

public class UnitOfWork(AddressManagementDbContext context) : IUnitOfWork
{
    private IRepository<Customer>? _customers;
    private IRepository<Address>? _addresses;
    
    public IRepository<Customer> Customers => _customers ??= new CustomerRepository(context);
    public IRepository<Address>  Addresses => _addresses  ??= new AddressRepository(context);

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}