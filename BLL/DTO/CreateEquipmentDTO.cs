namespace BLL.DTO;

public class CreateEquipmentDTO
{
    public string Name { get; set; }
    public string Type { get; set; }
    public Guid ContractId { get; set; }
}