using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeLogger.Shared
{
    public class UserRequestDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Province is required")]
        public int? ProvinceId { get; set; }

        [Required(ErrorMessage = "City is required")]
        public int? CityId { get; set; }

        [Required(ErrorMessage = "Suburb is required")]
        public int? SuburbId { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string StreetName { get; set; }



        [Range(typeof(bool), "true", "true", ErrorMessage = "Receive crime email notification option is required")]
        public bool IsEmailNotification { get; set; }
        public bool IsPushNotification { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Accept terms and conditions")]
        public bool IsTermsAccepted { get; set; }



        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm password is not matched")]
        public string ConfirmPassword { get; set; }

    }
}
