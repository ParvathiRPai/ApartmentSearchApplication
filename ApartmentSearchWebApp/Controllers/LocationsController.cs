using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentSearchWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentSearchWebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LocationsController : Controller
    {
        private ILocationsService _locationsService;

        public LocationsController(
            ILocationsService locationsService)
        {
            _locationsService = locationsService;
        }

        // GET: api/Locations
        [HttpGet]
        public IEnumerable<Location> Get()
        {
            var locations = _locationsService.GetLocations();
            return locations;
        }

        // GET: api/Locations/5
        [HttpGet("{name}")]
        public Location Get(string name)
        {
            return _locationsService.GetLocationByName(name);
        }
        
        // POST: api/Locations
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
