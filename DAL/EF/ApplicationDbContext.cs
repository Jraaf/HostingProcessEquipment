using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) 
    {

    }
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<EquipmentType> Equipments { get; set; }
    public DbSet<EquipmentContract> Contracts { get; set; }
}
