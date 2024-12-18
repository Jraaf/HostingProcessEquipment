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
        : base(context)
    {
        this.context = context;
    }
    public async new Task<List<EquipmentContract>> GetAllAsync()
    {
        return await context.Contracts
            .Include(c => c.Facility)
            .Include(c => c.Equipment)
            .ToListAsync();
    }

    public async Task<EquipmentType?> GetEquipmentById(int id)
    {
        return await context.Equipments
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Facility?> GetFacilityById(int id)
    {
        return await context.Facilities
            .FirstOrDefaultAsync(f => f.Id == id);
    }
}
