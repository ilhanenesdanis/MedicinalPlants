using DTO;
using DTO.PlantCategory;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using WebAPI.Constants;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlantCategoryController : Controller
    {
        private readonly IPlantsCategoryService _plantsCategoryService;
        
        public PlantCategoryController(IPlantsCategoryService plantsCategoryService)
        {
            _plantsCategoryService = plantsCategoryService;
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var data = _plantsCategoryService.GetPlantsCategory();
            if (data != null)
            {
                var SuccessResult = new ResultDTO<PlantsCategoryList>()
                {
                    DataList = data,
                    Status = true,
                    Message = Messages.ListelemeBaşarılı
                };
                return Ok(SuccessResult);
            }
            var ErrorResult = new ResultDTO<PlantsCategoryList>()
            {
                Status = false,
                Message = Messages.KayıtBulunamadı
            };
            return Ok(ErrorResult);
        }
        [HttpPost]
        public IActionResult AddNewCategory(AddPlantCategoryDto addPlantCategoryDto)
        {
            var status = _plantsCategoryService.AddPlantCategory(addPlantCategoryDto);
            if (status == 1)
            {
                var Succes = new ResultDTO<AddPlantCategoryDto>()
                {
                    Message = Messages.KayıtBaşarılı,
                    Status = true
                };
                return Ok(Succes);
            }
            var Error = new ResultDTO<AddPlantCategoryDto>()
            {
                Message = Messages.KayıtSırasındaHata,
                Status = false
            };
            return Ok(Error);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdatePlantsCategory updatePlants)
        {
            var status = _plantsCategoryService.UpdatePlantCategory(updatePlants);
            if (status == 1)
            {
                var Succes = new ResultDTO<AddPlantCategoryDto>()
                {
                    Message = Messages.GüncellemeIslemiBasarili,
                    Status = true
                };
                return Ok(Succes);
            }
            var Error = new ResultDTO<AddPlantCategoryDto>()
            {
                Message = Messages.GüncellemeSırasındaHata,
                Status = false
            };
            return Ok(Error);
        }
        [HttpDelete("{Id}")]
        public IActionResult RemoveCategory(int Id)
        {
            var getById = _plantsCategoryService.GetById(Id);
            if (getById != null)
            {
                _plantsCategoryService.Delete(getById);
                var Succes = new ResultDTO<AddPlantCategoryDto>()
                {
                    Message = Messages.SilmeIslemiBaşarılı,
                    Status = true
                };
                return Ok(Succes);
            }
            var Error = new ResultDTO<AddPlantCategoryDto>()
            {
                Message = Messages.SilmeIslemiSırasındaHata,
                Status = false
            };
            return Ok(Error);
        }
        [HttpPut("{Id}")]
        public IActionResult ChangeStatus(int Id)
        {
            var changeStatus = _plantsCategoryService.ChangeStatus(Id);
            if (changeStatus == 1)
            {
                var Succes = new ResultDTO<AddPlantCategoryDto>()
                {
                    Message = Messages.GüncellemeIslemiBasarili,
                    Status = true
                };
                return Ok(Succes);
            }
            var Error = new ResultDTO<AddPlantCategoryDto>()
            {
                Message = Messages.GüncellemeSırasındaHata,
                Status = false
            };
            return Ok(Error);
        }
    }
}
