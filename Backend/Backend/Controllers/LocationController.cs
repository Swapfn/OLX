using Mapper.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly ILocationMapper _locationMapper;
        public LocationController(ILocationService locationService, ILocationMapper locationMapper)
        {
            _locationService = locationService;
            _locationMapper = locationMapper;
        }

        [HttpGet]
        [Route("locations")]
        public IActionResult GetAll()
        {
            IEnumerable<LocationDTO> locationsDTO = _locationService.GetAll();
            return Ok(locationsDTO);
        }

        [HttpGet]
        [Route("locations/{id}")]
        public IActionResult GetById(int id)
        {
            LocationDTO locationDTO = _locationService.GetById(id);
            return Ok(locationDTO);
        }

        [HttpPost]
        [Route("locations")]
        public IActionResult Add(LocationDTO locationDTO)
        {
            _locationService.Add(locationDTO);
            _locationService.SaveLocation();
            return Ok(locationDTO);
        }

        [HttpPut]
        [Route("locations/{id}")]
        public IActionResult Update(int id, LocationDTO locationDTO)
        {
            _locationService.Update(id, locationDTO);
            _locationService.SaveLocation();
            return Ok(locationDTO);
        }

        [HttpDelete]
        [Route("locations/{id}")]
        public IActionResult Delete(int id)
        {
            _locationService.Delete(id);
            _locationService.SaveLocation();
            return Ok();
        }
    }
}
