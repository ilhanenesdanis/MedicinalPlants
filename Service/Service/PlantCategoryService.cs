using AutoMapper;
using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using DTO.PlantCategory;
using Service.IService;

namespace Service.Service
{
    public class PlantCategoryService : Service<PlantCategory>, IPlantsCategoryService
    {
        private readonly IRepository<PlantCategory> _plantsCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PlantCategoryService(IRepository<PlantCategory> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _plantsCategoryRepository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public int AddPlantCategory(AddPlantCategoryDto addPlantCategoryDto)
        {
            var entity = _mapper.Map<PlantCategory>(addPlantCategoryDto);
            entity.Status = true;
            entity.UpdateDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            _plantsCategoryRepository.Add(entity);
            var result = _unitOfWork.SaveChanges();
            return result;
        }

        public int ChangeStatus(int id)
        {
            var result = _plantsCategoryRepository.GetById(id);
            if (result != null)
            {
                result.Status = result.Status == true ? false : true;
                _plantsCategoryRepository.Update(result);
                var status = _unitOfWork.SaveChanges();
                return status;
            }
            return 0;
        }

        public List<PlantsCategoryList> GetPlantsCategory()
        {
            return _plantsCategoryRepository.GetAll().Select(x => new PlantsCategoryList { Id = x.Id, Name = x.Name,CreateDate=x.CreateDate,Status=x.Status }).ToList();
        }

        public List<PlantsCategoryList> GetPlantsCategoryByDropdown()
        {
            return _plantsCategoryRepository.GetAll().Select(x => new PlantsCategoryList { Id = x.Id, Name = x.Name }).ToList();
        }

        public int UpdatePlantCategory(UpdatePlantsCategory updatePlants)
        {
            var GetById = _plantsCategoryRepository.GetById(updatePlants.Id);
            GetById.Name = updatePlants.Name;
            GetById.UpdateDate = DateTime.Now;
            _plantsCategoryRepository.Update(GetById);
            var result = _unitOfWork.SaveChanges();
            return result;

        }
    }
}
