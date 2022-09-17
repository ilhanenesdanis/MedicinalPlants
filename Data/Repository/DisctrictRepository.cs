using Core.Entity;
using Core.IRepository;

namespace Data.Repository
{
    public class DisctrictRepository : Repository<District>, IDistrictRepository
    {
        public DisctrictRepository(Context context) : base(context)
        {
        }
    }
}
