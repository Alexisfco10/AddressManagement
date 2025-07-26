using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("Customer")]
public class Customer: BaseModel
{
    [Column("name")]
    [MaxLength(100)]
    public required string Name { get; set; }
    [Column("birthday")]
    public DateTime Birthday { get; set; }
    [Column("phoneNumber")]
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    [Column("email")]
    [MaxLength(100)]
    public string? Email { get; set; }
    public IEnumerable<Address>? Addresses { get; set; }
}