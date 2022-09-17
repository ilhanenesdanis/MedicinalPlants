using AutoMapper;
using Core.Entity;
using DTO.PlantCategory;
using DTO.Plants;

namespace Service.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AddPlantCategoryDto, PlantCategory>().ReverseMap();
            CreateMap<PlantsCategoryList, PlantCategory>().ReverseMap();
            CreateMap<UpdatePlantsCategory, PlantCategory>().ReverseMap();
            CreateMap<AddPlantDto, Plants>().ReverseMap();
        }
    }
}
