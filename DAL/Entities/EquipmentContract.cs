namespace DAL.Entities;

public class EquipmentContract
{
    public int Id { get; set; }
    public int FacilityId { get; set; }
    public int EquipmentId { get; set; }
    public Facility Facility { get; set; }
    public EquipmentType Equipment { get; set; }
    public int EquipmentCount { get; set; }
}
