﻿using Business.Repository.IRepository;
using CrimeLogger.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class CrimeCreateController : Controller
    {
        private readonly ICrimeDetailRepository _crimeDetailRepository;

        public CrimeCreateController(ICrimeDetailRepository crimeDetailRepository)
        {
            _crimeDetailRepository = crimeDetailRepository;
        }


        [HttpPost]
        public async Task<ActionResult<CrimeDetailDTO>> LogCrime([FromBody] CrimeDetailDTO crimeDetailDTO)
        {
            try
            {
                if (crimeDetailDTO == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var createdCrime = await _crimeDetailRepository.CreateCrime(crimeDetailDTO);

                return StatusCode(201);


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new crime record");
            }

        }
    }
}