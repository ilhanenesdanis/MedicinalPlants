using AutoMapper;
using Core.Entity;
using DTO;
using DTO.City;
using DTO.Disctrict;
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
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        private readonly IDistrictService _districtService;
        public PlantController(IPlantsService plantService, IPlantsImageService plantsImageService, IMapper mapper, IDistrictService districtService, ICityService cityService)
        {
            _plantService = plantService;
            _plantsImageService = plantsImageService;
            _mapper = mapper;
            _districtService = districtService;
            _cityService = cityService;
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
        [HttpGet("{Id}")]
        public IActionResult GetPlants(int Id)
        {
            var data = _plantService.GetByPlantsId(Id);
            if (data!=null)
            {
                var map=_mapper.Map<PlantsDto>(data);
                var successResult = new ResultDTO<PlantsDto>()
                {
                    Data = map,
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
        [HttpGet]
        public IActionResult GetCityList()
        {
            var data = _cityService.GetAll();
            if (data.Count > 0)
            {
                var map = _mapper.Map<List<CityDto>>(data);
                var successResult = new ResultDTO<CityDto>()
                {
                    DataList = map,
                    Message = Messages.ListelemeBaşarılı,
                    Status = true
                };
                return Ok(successResult);
            }
            var errorResult = new ResultDTO<CityDto>()
            {
                Message = Messages.KayıtBulunamadı,
                Status = false
            };
            return Ok(errorResult);
            
        }
        [HttpGet("{Id}")]
        public IActionResult GetDisctrict(int Id)
        {
            var data = _districtService.GetAll().Where(x => x.CityId == Id).ToList();
            if (data.Count > 0)
            {
                var map = _mapper.Map<List<DisctrictDto>>(data);
                var successResult = new ResultDTO<DisctrictDto>()
                {
                    DataList = map,
                    Message = Messages.ListelemeBaşarılı,
                    Status = true
                };
                return Ok(successResult);
            }
            var errorResult = new ResultDTO<DisctrictDto>()
            {
                Message = Messages.KayıtBulunamadı,
                Status = false
            };
            return Ok(errorResult);
        }
        [HttpGet]
        public IActionResult GetAllDisctrict()
        {
            var data = _districtService.GetAll().ToList();
            if (data.Count > 0)
            {
                var map = _mapper.Map<List<DisctrictDto>>(data);
                var successResult = new ResultDTO<DisctrictDto>()
                {
                    DataList = map,
                    Message = Messages.ListelemeBaşarılı,
                    Status = true
                };
                return Ok(successResult);
            }
            var errorResult = new ResultDTO<DisctrictDto>()
            {
                Message = Messages.KayıtBulunamadı,
                Status = false
            };
            return Ok(errorResult);
        }
        [HttpPost]
        public IActionResult Update(PlantsDto plantsDto)
        {
            var GetPlants = _plantService.GetById(plantsDto.PlantId);
            if (GetPlants != null)
            {
                Plants plants = new Plants()
                {
                    CategoryId = plantsDto.CategoryId,
                    CityId = plantsDto.CityId,
                    DisctrictId = plantsDto.DisctrictId,
                    Content = plantsDto.Content,
                    CreateDate = GetPlants.CreateDate,
                    Id = GetPlants.Id,
                    ImagePath = plantsDto.ImagePath,
                    Name = plantsDto.Name,
                    SmallContent = plantsDto.SmallContent,
                    Status = GetPlants.Status,
                    UpdateDate = DateTime.Now
                };
                _plantService.Update(plants);
                return Ok();
            }
            return Ok();
        }

    }
}
