﻿using AutoMapper;
using BLL.DTO;
using BLL.Services.Base;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class ContractService :
    Service<EquipmentContract, ContractDTO, CreateContractDTO>,
    IContractService
{
    public ContractService(IMapper _mapper, IContractRepositry _repo)
        : base(_repo, _mapper)
    {

    }
}
