using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) 
    {
        
    }
    public DbSet<ProductionFacility> Facilities { get; set; }
    public DbSet<ProcessEquipment> Equipments { get; set; }
    public DbSet<EquipmentProcessContract> Contracts { get; set; }
}
