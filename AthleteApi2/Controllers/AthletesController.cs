using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthleteLibrary;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AthleteApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthletesController : ControllerBase
    {
        private readonly AthleteManager _manager = new AthleteManager();


        /// <summary>
        /// Returns all athletes in our data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Athlete> GetAllAthletes()
        {
            return _manager.GetAllAthletes();
        }


        /// <summary>
        /// Finds an athlete by their country.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Country/{country}")]
        public IEnumerable<Athlete> GetByCountry(string country)
        {
            return _manager.GetByCountry(country);
        }
        /// <summary>
        /// Finds a specific athlete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public Athlete GetAthleteById(int id)
        {
            return _manager.GetById(id);
        }


        /// <summary>
        /// Adds an athlete  to our data.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public ActionResult<Athlete> Post([FromBody] Athlete value)
        {
            return Ok(_manager.Add(value));
        }


        /// <summary>
        /// Removes an athlete from our data.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Athlete> Delete(int id)
        {
            Athlete result = _manager.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result); 
            }
        }
    }
}
