using Business.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimeProvinceController : Controller
    {
        private readonly ICrimeProvinceRepository _crimeProvinceRepository;

        public CrimeProvinceController(ICrimeProvinceRepository crimeProvinceRepository)
        {
            _crimeProvinceRepository = crimeProvinceRepository;
        }

        [HttpGet]
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
