using Business.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CrimeTypeController : Controller
    {
        private readonly ICrimeTypeRepository _crimeTypeRepository;

        public CrimeTypeController(ICrimeTypeRepository crimeTypeRepository)
        {
            _crimeTypeRepository = crimeTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCrimeTypes()
        {
            var allTypes = await _crimeTypeRepository.GetAllCrimeTypes();

            if (allTypes==null)
            {
                return BadRequest();
            }
            return Ok(allTypes);
        }
    }
}
