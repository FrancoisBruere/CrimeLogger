using Business.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    [Authorize]
    public class CrimeCityController : Controller
    {
        private readonly ICrimeCityRepository _crimeCityRepository;

        public CrimeCityController(ICrimeCityRepository crimeCityRepository)
        {
            _crimeCityRepository = crimeCityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCrimeCitiesByProvinceId(int? provinceId)
        {
            if (provinceId == null)
            {
                return BadRequest();
            }

            var cityDetails = await _crimeCityRepository.GetCrimeCitiesByProvinceId(provinceId.Value);

            if (cityDetails == null)
            {
                return NotFound();
            }

            return Ok(cityDetails);
        }

    }
}
