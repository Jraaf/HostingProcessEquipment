using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Services.Base;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class ContractService :
    Service<EquipmentContract, ContractDTO, CreateContractDTO>,
    IContractService
{
    private readonly IMapper mapper;
    private readonly IContractRepositry repo;

    public ContractService(IMapper _mapper, IContractRepositry _repo)
        : base(_repo, _mapper)
    {
        mapper = _mapper;
        repo = _repo;
    }
    public async new Task<ContractDTO> AddAsync(CreateContractDTO dto)
    {
        var facility = await repo.GetFacilityById(dto.FacilityId);
        if (facility == null)
        {
            throw new ContractException("Provided facility is not found."); ;
        }

        var equipment = await repo.GetEquipmentById(dto.EquipmentId);
        if (facility == null)
        {
            throw new ContractException("Provided equipmnet is not found.");
        }

        if (equipment.Area * dto.EquipmentCount > facility.Area)
        {
            throw new ContractException($"There is not enough area for {dto.EquipmentCount} equipments");
        }

        return await base.AddAsync(dto);
    }
}
