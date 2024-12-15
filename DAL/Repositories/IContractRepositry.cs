using DAL.Entities;
using DAL.Repositories.Repo;

namespace DAL.Repositories;

public interface IContractRepositry : IRepo<EquipmentProcessContract, Guid>
{
}
