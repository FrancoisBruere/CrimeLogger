using Business.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]")]
    [Controller]
 
    public class AllCrimeCitiesController : Controller
    {
        private readonly ICrimeCityRepository _crimeCityRepository;

        public AllCrimeCitiesController(ICrimeCityRepository crimeCityRepository)
        {
            _crimeCityRepository = crimeCityRepository;
        }

        [HttpGet]
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