using Core.Entity;
using Core.IService;
using DTO.Plants;

namespace Service.IService
{
    public interface IPlantsService : IService<Plants>
    {
        List<PlantsDto> GetAllPlants();
        PlantsDto GetByPlantsId(int id);
        int AddPlant(AddPlantDto addPlant);
    }
}
