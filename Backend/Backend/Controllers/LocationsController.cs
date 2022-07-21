using Mapper.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly ILocationMapper _locationMapper;
        public LocationsController(ILocationService locationService, ILocationMapper locationMapper)
        {
            _locationService = locationService;
            _locationMapper = locationMapper;
        }

        // GET api/Locations
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            IEnumerable<LocationDTO> locationsDTO = _locationService.GetAll();
            return Ok(locationsDTO);
        }

        // GET api/Locations/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            LocationDTO locationDTO = _locationService.GetById(id);

            if (!LocationExists(id))
            {
                return NotFound();
            }

            return Ok(locationDTO);
        }

        // POST api/Locations
        [HttpPost]
        [Route("")]
        public IActionResult Add(LocationDTO locationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _locationService.Add(locationDTO);
            _locationService.SaveLocation();
            return Ok(locationDTO);
        }

        // PUT api/Locations/1
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, LocationDTO locationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locationDTO.LocationId)
            {
                return BadRequest();
            }

            if (!LocationExists(id))
            {
                return NotFound();
            }

            _locationService.Update(id, locationDTO);
            _locationService.SaveLocation();
            return Ok(locationDTO);
        }

        // DELETE api/Location/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (!LocationExists(id))
            {
                return NotFound();
            }
            _locationService.Delete(id);
            _locationService.SaveLocation();
            return Ok();
        }


        private bool LocationExists(int id)
        {
            LocationDTO locationDTO = _locationService.GetById(id);
            return locationDTO != null;
        }
    }
}
