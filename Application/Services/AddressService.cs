using Application.Dtos.Address;
using Application.Repository;
using Application.Services.Interface;
using Application.Shared.Mappers.Interface;
using Domain.Models;

namespace Application.Services;

public class AddressService(IAddressRepository repository, IAddressMapper mapper) 
    : BaseService<Address, AddressDto, AddressInsert, AddressUpdate>(repository, mapper), IAddressService
{
    
}