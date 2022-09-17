using DTO;
using DTO.Plants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using WebAPI.Constants;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly IPlantsService _plantService;
        private readonly IPlantsImageService _plantsImageService;
        public PlantController(IPlantsService plantService, IPlantsImageService plantsImageService)
        {
            _plantService = plantService;
            _plantsImageService = plantsImageService;
        }
        [HttpGet]
        public IActionResult GetAllPlants()
        {
            var data = _plantService.GetAllPlants();
            if (data.Count > 0)
            {
                var successResult = new ResultDTO<PlantsDto>()
                {
                    DataList = data,
                    Message = Messages.ListelemeBaşarılı,
                    Status = true
                };
                return Ok(successResult);
            }
            var errorResult = new ResultDTO<PlantsDto>()
            {
                Message = Messages.KayıtBulunamadı,
                Status = false
            };
            return Ok(errorResult);
        }
        [HttpPost]
        public IActionResult AddPlant(AddPlantDto addPlant)
        {
            var result = _plantService.AddPlant(addPlant);
            if (result == 1)
            {
                var successResult = new ResultDTO<PlantsDto>()
                {
                    Message = Messages.KayıtBaşarılı,
                    Status = true
                };
                return Ok(successResult);
            }
            var errorResult = new ResultDTO<PlantsDto>()
            {
                Message = Messages.KayıtSırasındaHata,
                Status = false
            };
            return Ok(errorResult);
        }
        [HttpGet("{id}")]
        public IActionResult DeletePlant(int id)
        {
            var result = _plantService.GetById(id);
            if (result != null)
            {
                _plantService.Delete(result);
                var succesResult = new ResultDTO<PlantsDto>()
                {
                    Message = Messages.SilmeIslemiBaşarılı,
                    Status = true
                };
                return Ok(succesResult);
            }
            var errorResult = new ResultDTO<PlantsDto>()
            {
                Message = Messages.SilmeIslemiSırasındaHata,
                Status = false
            };
            return Ok(errorResult);
        }
        [HttpGet("{id}")]
        public IActionResult ChangeStatus(int id)
        {
            var result = _plantService.GetById(id);
            if (result != null)
            {
                result.Status = result.Status == true ? false : true;
                result.UpdateDate = DateTime.Now;
                _plantService.Update(result);
                var succesResult = new ResultDTO<PlantsDto>()
                {
                    Message = Messages.GüncellemeIslemiBasarili,
                    Status = true
                };
                return Ok(succesResult);
            }
            var errorResult = new ResultDTO<PlantsDto>()
            {
                Message = Messages.GüncellemeSırasındaHata,
                Status = false
            };
            return Ok(errorResult);
        }
    }
}
