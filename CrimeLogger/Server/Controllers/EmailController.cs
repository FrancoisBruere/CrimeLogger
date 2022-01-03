using DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrimeLogger.Server.Controllers
{
    [Route("ConfirmEmail", Name = "Confirmation")]
    [ApiController]
    [Authorize]
    public class EmailController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public EmailController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
                return View("Error");

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                
                return View("ConfirmedEmail");
            }
            else
            {
                return View("emailconfirmerror");
            }
            
            
        }
    }
}
