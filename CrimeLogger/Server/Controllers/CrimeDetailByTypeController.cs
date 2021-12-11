using Business.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    [Authorize]
    public class CrimeDetailByTypeController : Controller
    {
        private readonly ICrimeDetailRepository _crimeDetailRepository;

        public CrimeDetailByTypeController(ICrimeDetailRepository crimeDetailRepository)
        {
            _crimeDetailRepository = crimeDetailRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetCrimesByTypeId(int? typeId)
        {
            if (typeId == null)
            {
                return BadRequest();

            }
            var crimeDetails = await _crimeDetailRepository.GetCrimeByType(typeId.Value);

            if (crimeDetails == null)
            {
                return BadRequest();

            }
            return Ok(crimeDetails);
        }
    }
}
