using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Repo;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ContractRepositry : Repo<EquipmentContract, int>, IContractRepositry
{
    private readonly ApplicationDbContext context;

    public ContractRepositry(ApplicationDbContext context)
        :base(context)
    {
        this.context = context;
    }
}
