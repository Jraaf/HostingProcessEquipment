namespace DAL.Entities;

public class ProcessEquipment : BaseEntity
{
    public Guid ContractId { get; set; } 
    public EquipmentProcessContract Contract { get; set; }
}
