using Business.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    [Authorize]
    
    public class AllCrimeCitiesController : Controller
    {
        private readonly ICrimeCityRepository _crimeCityRepository;

        public AllCrimeCitiesController(ICrimeCityRepository crimeCityRepository)
        {
            _crimeCityRepository = crimeCityRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCrimeCities()
        {
            var allCities = await _crimeCityRepository.GetAllCrimeCities();

            if (allCities == null)
            {
                return BadRequest();

            }
            return Ok(allCities);

        }

    }
}