using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpS301_API.Controllers
{
    [Route("api/cities")]
    public class CitiesController: Controller
    {
        [HttpGet()]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{cityId}")]
        public IActionResult GetCity(int cityId)
        {
            // Find city
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (cityToReturn == null)
            {
                return NotFound();
            } else
            {
                return Ok(cityToReturn);
            }
        }
    }
}
