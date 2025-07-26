using Application.Dtos.Address;
using Domain.Models;

namespace Application.Services.Interface;

public interface IAddressService : IService<Address, AddressDto, AddressInsert, AddressUpdate>
{
    
}