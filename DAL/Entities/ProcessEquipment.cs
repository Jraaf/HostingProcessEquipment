namespace DAL.Entities;

public class ProcessEquipment : BaseEntity
{
    public string Type { get; set; }
    public Guid ContractId { get; set; } 
    public EquipmentProcessContract Contract { get; set; }
}
