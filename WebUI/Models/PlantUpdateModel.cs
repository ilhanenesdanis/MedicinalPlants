using DTO.City;
using DTO.Disctrict;
using DTO.PlantCategory;
using DTO.Plants;

namespace WebUI.Models
{
    public class PlantUpdateModel
    {
        public PlantsDto Plants { get; set; }
        public List<CityDto> City { get; set; }
        public List<DisctrictDto> disctricts { get; set; }
        public List<PlantsCategoryList> Category { get; set; }
    }
}
