using Core.Entity;
using Core.IService;
using DTO.PlantCategory;

namespace Service.IService
{
    public interface IPlantsCategoryService:IService<PlantCategory>
    {
        List<PlantsCategoryList> GetPlantsCategory();
        int AddPlantCategory(AddPlantCategoryDto addPlantCategoryDto);
        int UpdatePlantCategory(UpdatePlantsCategory updatePlants);
        int ChangeStatus(int id);
    }
}
