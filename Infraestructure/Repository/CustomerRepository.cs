using Application.Repository;
using Domain.Models;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository;

public class CustomerRepository(AddressManagementDbContext dbContext) : Repository<Customer>(dbContext), ICustomerRepository
{
    public override async Task<Customer?> Get(long id, Func<IQueryable<Customer>, IQueryable<Customer>>? include = null)
    {
        return await DbSet
            .Include(c => c.Addresses)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public override async Task<IEnumerable<Customer>> GetAll(Func<IQueryable<Customer>, IQueryable<Customer>>? include = null)
    {
        return await DbSet
            .Include(c => c.Addresses).ToListAsync();
    }
}