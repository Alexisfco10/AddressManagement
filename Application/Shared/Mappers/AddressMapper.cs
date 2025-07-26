using Application.Dtos.Address;
using Application.Shared.Mappers.Interface;
using Domain.Models;

namespace Application.Shared.Mappers;

public class AddressMapper : IAddressMapper
{
    public Address ToModel(AddressDto dto)
    {
        return new Address()
        {
            Id = dto.Id,
            AddressLine = dto.AddressLine,
            Country = dto.Country,
            State = dto.State,
            ZipCode = dto.ZipCode,
            CustomerId = dto.CustomerId,
        };
    }

    public Address ToModel(AddressInsert dto)
    {
        return new Address()
        {
            AddressLine = dto.AddressLine,
            Country = dto.Country,
            State = dto.State,
            ZipCode = dto.ZipCode,
            CustomerId = dto.CustomerId,
        };
    }

    public Address ToModel(Address model, AddressUpdate request)
    {
        model.Id = request.Id;
        model.AddressLine = request.AddressLine;
        model.Country = request.Country;
        model.State = request.State;
        model.ZipCode = request.ZipCode;
        model.CustomerId = request.CustomerId;
        return model;
    }

    public AddressDto ToDto(Address model)
    {
        return new AddressDto()
        {
            Id = model.Id,
            AddressLine = model.AddressLine,
            Country = model.Country,
            State = model.State,
            ZipCode = model.ZipCode,
            CustomerId = model.CustomerId,
        };
    }
}