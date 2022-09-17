using AutoMapper;
using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using DTO.Plants;
using Service.IService;

namespace Service.Service
{
    public class PlantsService : Service<Plants>, IPlantsService
    {
        private readonly IPlantsRepository _plantsRepository;
        private readonly IPlantsImageRepository _plantsImageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PlantsService(IRepository<Plants> repository, IUnitOfWork unitOfWork, IPlantsRepository plantsRepository, IPlantsImageRepository plantsImageRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _plantsRepository = plantsRepository;
            _plantsImageRepository = plantsImageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int AddPlant(AddPlantDto addPlant)
        {
            var mapping = _mapper.Map<Plants>(addPlant);
            mapping.Status = true;
            mapping.CreateDate = DateTime.Now;
            _plantsRepository.Add(mapping);
            var status = _unitOfWork.SaveChanges();
            if (addPlant.ImageList.Count > 0)
            {
                foreach (var item in addPlant.ImageList)
                {
                    PlantsImage plants = new PlantsImage()
                    {
                        CreateDate = DateTime.Now,
                        ImagePath = item,
                        PlantId = mapping.Id,
                        Status = true,
                        UpdateDate = DateTime.Now,

                    };
                    _plantsImageRepository.Add(plants);
                }
                var save = _unitOfWork.SaveChanges();
            }
            return status;
        }

        public List<PlantsDto> GetAllPlants()
        {
            return _plantsRepository.GetAllPlants().Select(x => 
            new PlantsDto { CategoryName = x.PlantCategory.Name, ImagePath = x.ImagePath, Name = x.Name, PlantId = x.Id ,CreateDate=x.CreateDate,Status=x.Status}).ToList();
        }
    }
}
