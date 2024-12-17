using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Repo;

namespace DAL.Repositories;

public class EquipmentRepository : Repo<EquipmentType, int>, IEquipmentRepository
{
    public EquipmentRepository(ApplicationDbContext context)
        : base(context)
    {

    }
}
