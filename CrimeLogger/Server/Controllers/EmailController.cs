using DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

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
            //try
            //{
            //    token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception(ex.Message);
            //}

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                
                return View("confirmedemail");
            }
            else
            {
                return View("emailconfirmerror");
            }
            
            
        }
    }
}
