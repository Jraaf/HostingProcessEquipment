namespace BLL.DTO;

public class CreateContractDTO
{
    public string Name { get; set; }
    public Guid ProductuctionFacilityId { get; set; }
    public Guid ProcessEquipmentId { get; set; }
}
