using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
}
