using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public abstract class BaseModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }
}