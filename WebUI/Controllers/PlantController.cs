using DTO;
using DTO.Plants;
using Microsoft.AspNetCore.Mvc;
using WebUI.ApiHandler;
using WebUI.Helpers;

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

        }
    }
}
