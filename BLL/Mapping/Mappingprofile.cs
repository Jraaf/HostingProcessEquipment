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

        CreateMap<EquipmentContract, ContractDTO>()
            .ForMember(dest => dest.FacilityName, opt => opt.MapFrom(src => src.Facility.Name)) 
            .ForMember(dest => dest.EquipmentTypeName, opt => opt.MapFrom(src => src.Equipment.Name)); 
        CreateMap<CreateContractDTO, EquipmentContract>();

        CreateMap<CreateProductionFacilityDTO, Facility>();
        CreateMap<Facility, ProductionFacilityDTO>();
    }
}
