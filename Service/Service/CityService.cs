using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using Service.IService;

namespace Service.Service
{
    public class CityService : Service<City>, ICityService
    {
        public CityService(IRepository<City> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
