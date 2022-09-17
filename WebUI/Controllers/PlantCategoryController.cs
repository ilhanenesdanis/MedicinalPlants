using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class PlantCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
