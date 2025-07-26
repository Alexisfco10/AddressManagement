namespace Application.Dtos.Address;

public class AddressDto: IBaseDto
{
    public long Id { get; init; }
    public required string AddressLine { get; init; }
    public required string Country { get; init; }
    public required string State { get; init; }

    public required string ZipCode { get; init; }
    public required long CustomerId { get; init; }
}