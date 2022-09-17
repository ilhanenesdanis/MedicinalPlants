using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using Service.IService;

namespace Service.Service
{
    public class DisctrictService : Service<District>, IDistrictService
    {
        public DisctrictService(IRepository<District> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
