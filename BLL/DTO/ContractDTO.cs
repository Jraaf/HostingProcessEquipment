namespace BLL.DTO;

public class ContractDTO
{
    public int Id { get; set; }
    public int FacilityId { get; set; }
    public int EquipmentId { get; set; }
    public string FacilityName { get; set; } // Assuming you want to map Facility name
    public string EquipmentTypeName { get; set; } // Assuming you want to map Equipment name/type
    public int EquipmentCount { get; set; }
}
