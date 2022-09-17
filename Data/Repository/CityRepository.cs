using Core.Entity;
using Core.IRepository;

namespace Data.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(Context context) : base(context)
        {
        }
    }
}
