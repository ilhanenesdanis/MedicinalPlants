using Core.Entity;
using Core.IRepository;

namespace Data.Repository
{
    public class PlantCategoryRepository : Repository<PlantCategory>, IPlantCategoryRepository
    {
        public PlantCategoryRepository(Context context) : base(context)
        {
        }
    }
}
