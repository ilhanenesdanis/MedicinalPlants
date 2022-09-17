using Core.Entity;
using Core.IService;
using DTO.Plants;

namespace Service.IService
{
    public interface IPlantsService : IService<Plants>
    {
        List<PlantsDto> GetAllPlants();
        int AddPlant(AddPlantDto addPlant);
    }
}
