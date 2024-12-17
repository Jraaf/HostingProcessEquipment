using AutoMapper;
using BLL.DTO;
using BLL.Services.Base;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class EquipmentService :
    Service<EquipmentType, EquipmentDTO, CreateEquipmentDTO>,
    IEquipmentService
{
    public EquipmentService(IEquipmentRepository _repo, IMapper _mapper)
        : base(_repo, _mapper)
    {

    }
}
