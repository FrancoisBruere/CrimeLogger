using Business.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class AllCrimeSuburbsController : Controller
    {

        private readonly ICrimeSuburbRepository _crimeSuburbRepository;

        public AllCrimeSuburbsController(ICrimeSuburbRepository crimeSuburbRepository)
        {
            _crimeSuburbRepository = crimeSuburbRepository;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllCrimeSuburbs()
        {
            var allSuburbs = await _crimeSuburbRepository.GetAllCrimeSuburbs();

            if (allSuburbs == null)
            {
                return BadRequest();

            }
            return Ok(allSuburbs);

        }

    }
}
