using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using Service.IService;

namespace Service.Service
{
    public class PlantsImageService : Service<PlantsImage>, IPlantsImageService
    {
        public PlantsImageService(IRepository<PlantsImage> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
