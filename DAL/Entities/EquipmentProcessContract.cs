namespace DAL.Entities;

public class EquipmentProcessContract : BaseEntity
{
    public Guid ProductuctionFacilityId { get; set; }
    public Guid ProcessEquipmentId { get; set; }
    public ProductionFacility ProductionFacility { get; set; }
    public List<ProcessEquipment> Equipments { get; set; }
}
