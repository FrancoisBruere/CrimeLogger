using Business.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    [Authorize]
    public class CrimeProvinceController : Controller
    {
        private readonly ICrimeProvinceRepository _crimeProvinceRepository;

        public CrimeProvinceController(ICrimeProvinceRepository crimeProvinceRepository)
        {
            _crimeProvinceRepository = crimeProvinceRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCrimeProvinces()
        {
            var allProvinces = await _crimeProvinceRepository.GetAllCrimeProvinces();

            if (allProvinces == null)
            {

                return NotFound();
            }

            return Ok(allProvinces);
        }
    }
}
