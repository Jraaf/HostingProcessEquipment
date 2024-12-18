using DAL.Entities;
using DAL.Repositories.Repo;

namespace DAL.Repositories.Interfaces;

public interface IContractRepositry : IRepo<EquipmentContract, int>
{
    Task<Facility?> GetFacilityById(int id);
    Task<EquipmentType?> GetEquipmentById(int id);
}
