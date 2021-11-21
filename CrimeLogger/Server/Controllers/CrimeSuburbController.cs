﻿using Business.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class CrimeSuburbController : Controller
    {
        private readonly ICrimeSuburbRepository _crimeSuburbRepository;

        public CrimeSuburbController(ICrimeSuburbRepository crimeSuburbRepository)
        {
            _crimeSuburbRepository = crimeSuburbRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCrimeSuburbsByCityId(int? cityId) 
        {
            if (cityId == null)
            {
                return BadRequest();
            }

            var suburbDetails = await _crimeSuburbRepository.GetCrimeSuburbByCityId(cityId.Value);

            if (suburbDetails == null)
            {
                return NotFound();
            }


            return Ok(suburbDetails);

        }

    }
}