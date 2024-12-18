using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Services.Base;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class FacilityService :
    Service<Facility, ProductionFacilityDTO, CreateProductionFacilityDTO>,
    IFacilityService
{
    public FacilityService(IFacilityRepository _repo, IMapper _mapper)
        : base(_repo, _mapper)
    {

    }
    public async new Task<ProductionFacilityDTO> AddAsync(CreateProductionFacilityDTO dto)
    {
        if (dto.Area <= 0)
        {
            throw new ContractException("Area can not be 0 or negative.");
        }
        return await base.AddAsync(dto);
    }
}
