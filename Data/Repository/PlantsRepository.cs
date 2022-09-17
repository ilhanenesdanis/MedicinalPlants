using Core.Entity;
using Core.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class PlantsRepository : Repository<Plants>, IPlantsRepository
    {
        public PlantsRepository(Context context) : base(context)
        {
        }

        public IQueryable<Plants> GetAllPlants()
        {
            return _context.Plants.Include(x => x.PlantCategory).AsNoTracking().AsSplitQuery();
        }
    }
}
