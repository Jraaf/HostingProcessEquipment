using AutoMapper;
using BLL.DTO;
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
}
