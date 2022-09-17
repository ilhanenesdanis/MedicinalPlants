using Core.Entity;
using Core.IRepository;

namespace Data.Repository
{
    public class PlantsImageRepository : Repository<PlantsImage>, IPlantsImageRepository
    {
        public PlantsImageRepository(Context context) : base(context)
        {
        }
    }
}
