using DAL.Entities;
using DAL.Repositories.Repo;

namespace DAL.Repositories.Interfaces;

public interface IEquipmentRepository : IRepo<EquipmentType, int>
{
}
