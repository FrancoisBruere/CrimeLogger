using Business.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    [Authorize]
    public class CrimeDetailController : Controller
    {
        private readonly ICrimeDetailRepository _crimeDetailRepository;

        public CrimeDetailController(ICrimeDetailRepository crimeDetailRepository)
        {
            _crimeDetailRepository = crimeDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCrimeDetails()
        {
            var allCrimes = await _crimeDetailRepository.GetAllCrimes();

            if (allCrimes == null)
            {
                return BadRequest();

            }
            return Ok(allCrimes);

        }
    }
}
