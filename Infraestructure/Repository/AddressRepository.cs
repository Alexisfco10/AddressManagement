using Application.Repository;
using Domain.Models;
using Infraestructure.Context;

namespace Infraestructure.Repository;

public class AddressRepository(AddressManagementDbContext dbContext) : Repository<Address>(dbContext), IAddressRepository;