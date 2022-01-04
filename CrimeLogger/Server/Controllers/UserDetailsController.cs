using Business.Repository.IRepository;
using CrimeLogger.Shared;
using DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]   
    
    public class UserDetailsController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserUpdateRepository _userUpdateRepository;

        public UserDetailsController(UserManager<ApplicationUser> userManager, IUserUpdateRepository userUpdateRepository)
        {
            _userManager = userManager;
            _userUpdateRepository = userUpdateRepository;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserForUpdate(string email)
        {
            var currentUser = await _userManager.FindByNameAsync(email);
            if (currentUser == null)
            {
                return NotFound();
            }
            else
            {
               return Ok(currentUser);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserDetails([FromBody] UserUpdateDTO userUpdateDTO)
        {
            if (userUpdateDTO == null)
            {
                return BadRequest();
            }
            else
            {
                var result = await _userUpdateRepository.UpdateUserProfile(userUpdateDTO);
                return Ok(userUpdateDTO);
            }
        }


    }
}
