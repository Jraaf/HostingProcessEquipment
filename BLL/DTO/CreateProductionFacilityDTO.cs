using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class CreateProductionFacilityDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    public double Area { get; set; }
}
