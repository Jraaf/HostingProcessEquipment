using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class CreateContractDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int FacilityId { get; set; }
    [Required]
    public int EquipmentId { get; set; }
    [Required]
    public int EquipmentCount { get; set; }
}
