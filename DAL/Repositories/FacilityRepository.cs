using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories;

public class FacilityRepository : Repo<Facility, int>, IFacilityRepository
{
    public FacilityRepository(ApplicationDbContext context)
        :base(context)
    {
        
    }
}
