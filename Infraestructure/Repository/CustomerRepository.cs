using Application.Repository;
using Domain.Models;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository;

public class CustomerRepository(AddressManagementDbContext dbContext) : Repository<Customer>(dbContext), ICustomerRepository;