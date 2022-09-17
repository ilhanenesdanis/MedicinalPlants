using DTO;
using DTO.PlantCategory;
using Microsoft.AspNetCore.Mvc;
using WebUI.ApiHandler;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class PlantCategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiHandler _apiHandler;

        public PlantCategoryController(IApiHandler apiHandler, IConfiguration configuration)
        {
            _apiHandler = apiHandler;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetAllPlantCategory;
            var result = _apiHandler.GetApi<ResultDTO<PlantsCategoryList>>(url);
            return View(result);
        }
        [HttpPost]
        public JsonResult AddPlantCategory(AddPlantCategoryDto addPlantCategory)
        {
            var url = _configuration["BaseURL"] + UrlStrings.AddNewCategory;
            var result = _apiHandler.PostApi<ResultDTO<AddPlantCategoryDto>>(addPlantCategory, url);
            return Json(new { success = true });
        }
        public JsonResult ChangeStatusCategory(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.CategoryChangeStatus + id;
            var response = _apiHandler.GetApi<ResultDTO<AddPlantCategoryDto>>(url);
            return Json(new { success = true });
        }
        public JsonResult DeletePlantCategory(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.RemoveCategory + id;
            var response = _apiHandler.GetApi<ResultDTO<AddPlantCategoryDto>>(url);
            return Json(new { success = true });
        }
        public IActionResult UpdatePlantCategory(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetByCategoryId + id;
            var response = _apiHandler.GetApi<ResultDTO<PlantsCategoryList>>(url);
            return PartialView("_updatePlantCategory", response);
        }
        [HttpPost]
        public JsonResult UpdateCategory(UpdatePlantsCategory updatePlants)
        {
            var url = _configuration["BaseURL"] + UrlStrings.UpdateCategory;
            var response = _apiHandler.PostApi<ResultDTO<AddPlantCategoryDto>>(updatePlants, url);
            return Json(new { success = true });
        }
    }
}
