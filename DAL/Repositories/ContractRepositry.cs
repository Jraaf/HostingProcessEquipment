using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Repo;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ContractRepositry : Repo<EquipmentProcessContract, Guid>, IContractRepositry
{
    private readonly ApplicationDbContext context;

    public ContractRepositry(ApplicationDbContext context)
        :base(context)
    {
        this.context = context;
    }
    public async new Task<List<EquipmentProcessContract>> GetAllAsync()
    {
        return await context.Contracts
            .Include(c=>c.ProductionFacility)
            .Include(c=>c.Equipments)
            .ToListAsync();
    }
}
