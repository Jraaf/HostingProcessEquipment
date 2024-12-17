using BLL.DTO;
using BLL.Services.Base;
using DAL.Entities;

namespace BLL.Services.Interfaces;

public interface IEquipmentService : IService<EquipmentType, EquipmentDTO, CreateEquipmentDTO>
{
}
