namespace Application.Dtos.Customer;

public class CustomerUpdate : UpdateDto
{
    public required string Name { get; set; }
    public required string Birthday { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
}