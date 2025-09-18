using Application.Repository;
using Domain.Models;

namespace Application.UnitOfWork;

public interface IUnitOfWork
{
    public IRepository<Customer> Customers { get; }
    public IRepository<Address> Addresses { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}