using System.Globalization;
using Application.Dtos.Address;
using Application.Dtos.Customer;
using Application.Shared.Mappers.Interface;
using Domain.Models;

namespace Application.Shared.Mappers;

public class CustomerMapper : ICustomerMapper
{
    private static readonly string DateFormat = "dd/MM/yyyy";

    public Customer ToModel(CustomerDto dto)
    {
        return new Customer()
        {
            Id = dto.Id,
            Name = dto.Name,
            Birthday = DateTime.ParseExact(dto.Birthday, DateFormat, CultureInfo.InvariantCulture),
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Addresses = dto.AdressList?.Select(a => new Address()
            {
                Id = a.Id,
                AddressLine = a.AddressLine,
                Country = a.Country,
                State = a.State,
                ZipCode = a.ZipCode,
                CustomerId = a.CustomerId
            }).ToList() ?? new List<Address>()
        };
    }

    public Customer ToModel(CustomerInsert dto)
    {
        return new Customer()
        {
            Name = dto.Name,
            Birthday = DateTime.ParseExact(dto.Birthday, DateFormat, CultureInfo.InvariantCulture),
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
        };
    }

    public Customer ToModel(Customer model, CustomerUpdate request)
    {
        model.Id = request.Id;
        model.Name = request.Name;
        model.Birthday = DateTime.ParseExact(request.Birthday, DateFormat, CultureInfo.InvariantCulture);
        model.Email = request.Email;
        model.PhoneNumber = request.PhoneNumber;
        return model;
    }


    public CustomerDto ToDto(Customer model)
    {
        return new CustomerDto()
        {
            Id = model.Id,
            Name = model.Name,
            Birthday = model.Birthday.ToString(DateFormat, CultureInfo.InvariantCulture),
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            AdressList = model.Addresses?.Select(a => new AddressDto
            {
                Id = a.Id,
                AddressLine = a.AddressLine,
                Country = a.Country,
                State = a.State,
                ZipCode = a.ZipCode,
                CustomerId = a.CustomerId
            }).ToList() ?? new List<AddressDto>()
        };
    }
}