using Business.Repository.IRepository;
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
