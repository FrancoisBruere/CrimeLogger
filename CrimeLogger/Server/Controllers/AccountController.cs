using Common;
using CrimeLogger.Server.Helper;
using CrimeLogger.Shared;
using CrimeLoggger_Server.Helper;
using DataAccess.Data;
using Google.Authenticator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly APISettings _aPISettings;

        public AccountController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<APISettings> options,
            IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _aPISettings = options.Value;
            _emailSender = emailSender;

        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] UserRequestDTO userRequestDTO)
        {
            if (userRequestDTO == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

                var user = new ApplicationUser
                {
                    UserName = userRequestDTO.Email,
                    Email = userRequestDTO.Email,

                    ProvinceId = (int)userRequestDTO.ProvinceId,
                    CityId = (int)userRequestDTO.CityId,
                    SuburbId = (int)userRequestDTO.SuburbId,
                    StreetName = userRequestDTO.StreetName,

                    PhoneNumber = userRequestDTO.PhoneNo,

                    IsEmailNotification = userRequestDTO.IsEmailNotification,
                    IsTermsAccepted = userRequestDTO.IsTermsAccepted,
                    //EmailConfirmed = true  // Change to send to user with confirmation link
                };

                var result = await _userManager.CreateAsync(user, userRequestDTO.Password);

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(new RegistrationResponseDTO { Errors = errors, isRegistrationSuccessful = false });
                }
                //send email link
                try
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var confirmationLink = Url.Link("Confirmation", new { token, email = user.Email });

                    await _emailSender.SendEmailAsync(user.Email, "Account Confirmation Link - CrimeLogger",
                    $"Please confirm your account by clicking <a href=\"" + confirmationLink + "\">here</a>");
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }

                var roleResult = await _userManager.AddToRoleAsync(user, SD.Role_User);

                if (!roleResult.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(new RegistrationResponseDTO { Errors = errors, isRegistrationSuccessful = false });
                }

                return StatusCode(201);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] AuthenticationDTO authenticationDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(authenticationDTO.UserName, authenticationDTO.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(authenticationDTO.UserName);
                if (user == null)
                {
                    return Unauthorized(new AuthenticationResponseDTO
                    {
                        isAuthSuccessful = false,
                        ErrorMessage = "Invalid Authentication"
                    });
                }
                
                // Valid account
                
                var signinCredentials = GetSigningCredentials();
                var claims = await GetClaims(user);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _aPISettings.ValidIssuer,
                    audience: _aPISettings.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(SD.TokenLifeInDays),
                    signingCredentials: signinCredentials);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new AuthenticationResponseDTO
                {
                    isAuthSuccessful = true,
                    Token = token,
                    UserDTO = new UserDTO
                    {
                        Id = user.Id,
                        Name = user.Email,
                        Email = user.Email,
                        PhoneNo = user.PhoneNumber
                    }
                });
            }
            else
            {
                // Check if user email is confirmed 
                var user = await _userManager.FindByNameAsync(authenticationDTO.UserName);

                if (user == null)
                {
                    return Unauthorized(new AuthenticationResponseDTO
                    {
                        isAuthSuccessful = false,
                        ErrorMessage = "Invalid Authentication"
                    });
                }

                if (user.EmailConfirmed == false)
                {
                    return Unauthorized(new AuthenticationResponseDTO
                    {
                        isAuthSuccessful = false,
                        ErrorMessage = "Email not confirmed"
                    });
                }

                return Unauthorized(new AuthenticationResponseDTO
                {
                    isAuthSuccessful = false,
                    ErrorMessage = "Invalid Authentication"

                });
            }

        }
        private SigningCredentials GetSigningCredentials()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_aPISettings.SecretKey));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("Id",user.Id),
            };

            var roles = await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

   
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            if (!ModelState.IsValid)
                return View(forgotPasswordDTO);
            var user = await _userManager.FindByEmailAsync(forgotPasswordDTO.Email);
            if (user == null)
             // return StatusCode(StatusCodes.Status404NotFound, "User Not Found");
            return RedirectToPage("/forgotpassword");
            // return RedirectToAction(nameof(ForgotPasswordConfirmation));

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action(nameof(ResetPasswordLink), "Account", new { token, email = user.Email }, Request.Scheme);

           
            await _emailSender.SendEmailAsync(user.Email, "Reset password Link - CrimeLogger",
               $"Please reset your password by clicking <a href=\"" + callback + "\">here</a>");

            return Ok();
          
        }
       

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordLink(string token, string email)
        {
            var model = new ResetPasswordDTO { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromHeader] ResetPasswordDTO resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordModel);
            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                return RedirectToPage("/forgotpassword");
            
            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
           
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

       
    }
}
