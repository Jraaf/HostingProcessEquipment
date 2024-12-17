using BLL.DTO;
using BLL.Services.Base;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces;

public interface IContractService:IService<EquipmentContract, ContractDTO,CreateContractDTO>
{
}
