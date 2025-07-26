using Application.Dtos.Address;

namespace Application.Dtos.Customer;

public class CustomerDto : IBaseDto
{
    public long Id { get; init; }
    public required string Name { get; init; }
    public required string Birthday { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Email { get; init; }
    public IEnumerable<AddressDto>? AdressList { get; init; }
}