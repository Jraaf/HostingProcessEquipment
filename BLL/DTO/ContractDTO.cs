namespace BLL.DTO;

public class ContractDTO
{
    public int Id { get; set; }
    public int FacilityId { get; set; }
    public int EquipmentId { get; set; }
    public string FacilityName { get; set; } 
    public string EquipmentTypeName { get; set; } 
    public int EquipmentCount { get; set; }
}
