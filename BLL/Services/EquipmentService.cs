using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Services.Base;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace BLL.Services;

public class EquipmentService :
    Service<EquipmentType, EquipmentDTO, CreateEquipmentDTO>,
    IEquipmentService
{
    public EquipmentService(IEquipmentRepository _repo, IMapper _mapper)
        : base(_repo, _mapper)
    {

    }
    public async new Task<EquipmentDTO> AddAsync(CreateEquipmentDTO dto)
    {
        if(dto.Area<=0 )
        {
            throw new ContractException("Area can not be 0 or negative.");
        }
        return await base.AddAsync(dto);
    }
}
