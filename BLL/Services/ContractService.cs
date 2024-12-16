using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class ContractService(IMapper _mapper, IContractRepositry _repo) : IContractService
{
    public async Task<ContractDTO> AddAsync(CreateContractDTO dto)
    {
        var data = _mapper.Map<EquipmentProcessContract>(dto);
        var result = await _repo.AddAsync(data);
        return _mapper.Map<ContractDTO>(result);
    }

    public async Task<List<ContractDTO>> GetAllAsync()
    {
        var data = await _repo.GetAllAsync();
        return _mapper.Map<List<ContractDTO>>(data);
    }
}
