using Application.Dtos.Address;
using Domain.Models;

namespace Application.Shared.Mappers.Interface;

public interface IAddressMapper : IMapper<Address, AddressDto, AddressInsert, AddressUpdate>
{
    
}