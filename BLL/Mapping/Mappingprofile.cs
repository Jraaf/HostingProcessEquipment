using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateEquipmentDTO, ProcessEquipment>();
        CreateMap<EquipmentProcessContract, ContractDTO>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductionFacility.Name))
           .ForMember(dest => dest.ProductionFacility, opt => opt.MapFrom(src => src.ProductionFacility))
           .ForMember(dest => dest.NumberOfEquipment, opt => opt.MapFrom(src => src.Equipments != null ? src.Equipments.Count : 0));
        CreateMap<CreateContractDTO, EquipmentProcessContract>();
        CreateMap<ProcessEquipment, EquipmentDTO>();
    }
}
