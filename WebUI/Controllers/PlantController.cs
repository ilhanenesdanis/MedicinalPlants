using DTO;
using DTO.City;
using DTO.Disctrict;
using DTO.PlantCategory;
using DTO.Plants;
using Microsoft.AspNetCore.Mvc;
using WebUI.ApiHandler;
using WebUI.Helpers;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class PlantController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiHandler _apiHandler;
        private readonly IFileUpload _fileUpload;

        public PlantController(IFileUpload fileUpload, IApiHandler apiHandler, IConfiguration configuration)
        {
            _fileUpload = fileUpload;
            _apiHandler = apiHandler;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetAllPlant;
            var result = _apiHandler.GetApi<ResultDTO<PlantsDto>>(url);

            return View(result);
        }
        public JsonResult DeletePlant(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.DeletePlant + id;
            var result = _apiHandler.GetApi<ResultDTO<PlantsDto>>(url);
            return Json(new { success = true });
        }
        public JsonResult ChangeStatus(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.ChangeStatus + id;
            var result = _apiHandler.GetApi<ResultDTO<PlantsDto>>(url);
            return Json(new { success = true });
        }
        public JsonResult GetCategoryList()
        {
            ResultDTO<PlantsCategoryList> result = GetAllCategory();
            return Json(result.DataList);
        }

        private ResultDTO<PlantsCategoryList> GetAllCategory()
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetPlantsCategoryByDropdown;
            var result = _apiHandler.GetApi<ResultDTO<PlantsCategoryList>>(url);
            return result;
        }

        public JsonResult AddPlant(AddPlantDto addPlant, IFormFile file)
        {
            addPlant.ImagePath = _fileUpload.FileUploads(file);
            var url = _configuration["BaseURL"] + UrlStrings.AddPlant;
            var response = _apiHandler.PostApi<ResultDTO<AddPlantDto>>(addPlant, url);
            return Json(new { success = true });
        }
        public JsonResult GetCityList()
        {
            ResultDTO<CityDto> response = CityList();
            return Json(response.DataList);
        }

        private ResultDTO<CityDto> CityList()
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetCityList;
            var response = _apiHandler.GetApi<ResultDTO<CityDto>>(url);
            return response;
        }

        public JsonResult DisctrictList(int id)
        {
            ResultDTO<DisctrictDto> response = DistrictList(id);
            return Json(response.DataList);
        }

        private ResultDTO<DisctrictDto> DistrictList(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetDisctrict + id;
            var response = _apiHandler.GetApi<ResultDTO<DisctrictDto>>(url);
            return response;
        }
        private ResultDTO<DisctrictDto> DistrictAllList()
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetAllDisctrict;
            var response = _apiHandler.GetApi<ResultDTO<DisctrictDto>>(url);
            return response;
        }

        public IActionResult UpdatePlants(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetPlants + id;
            var response = _apiHandler.GetApi<ResultDTO<PlantsDto>>(url);
            PlantUpdateModel model = new PlantUpdateModel()
            {
                Plants = response.Data,
                disctricts = DistrictAllList().DataList,
                City = CityList().DataList,
                Category= GetAllCategory().DataList
            };
            return PartialView("_updatePlant",model);

        }
        public JsonResult Update(PlantsDto plants,IFormFile file)
        {
            if (file != null)
            {
                plants.ImagePath = _fileUpload.FileUploads(file);
            }
            var url = _configuration["BaseURL"] + UrlStrings.Update;
            var response = _apiHandler.PostApiString(plants, url);
            return Json(new { success = true });

        }
       
    }
}
