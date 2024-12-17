using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateEquipmentDTO, EquipmentType>();
        CreateMap<EquipmentType, EquipmentDTO>();

        CreateMap<EquipmentContract, ContractDTO>();
        CreateMap<CreateContractDTO, EquipmentContract>();

        CreateMap<CreateProductionFacilityDTO, Facility>();
        CreateMap<Facility, ProductionFacilityDTO>();
    }
}
