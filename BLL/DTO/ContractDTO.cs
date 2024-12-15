namespace BLL.DTO;

public class ContractDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ProductionFacilityDTO ProductionFacility { get; set; }
    public int NumberOfEquipment { get; set; }
}
