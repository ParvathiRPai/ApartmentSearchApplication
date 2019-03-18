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
    public class ApartmentsController : Controller
    {
        private IApartmentService _apartmentService;

        public ApartmentsController(IApartmentService apartmentService)
        {
            this._apartmentService = apartmentService;
        }

        // GET: api/Apartments
        [HttpGet]
        public async Task<IList<Apartment>> GetAsync()
        {
            return await _apartmentService.GetApartmentsAsync();
        }
        
        // POST: api/Apartments
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Apartments/5
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
