namespace Application.Dtos.Address;

public class AddressUpdate : UpdateDto
{
    public required string AddressLine { get; set; }
    public required string Country { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
    public required long CustomerId { get; set; }
}