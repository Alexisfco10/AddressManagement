using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("Address")]
public class Address: BaseModel
{
    [Column("addressLine")]
    [MaxLength(100)]
    public required string AddressLine { get; set; }
    [Column("country")]
    [MaxLength(30)]
    public required string Country { get; set; }
    [Column("state")]
    [MaxLength(30)]
    public required string State { get; set; }
    [Column("zipCode")]
    [MaxLength(15)]
    public required string ZipCode { get; set; }
    [Column("customerId")]
    public required long CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer? Customer { get; init; }
}