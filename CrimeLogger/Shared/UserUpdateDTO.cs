using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeLogger.Shared
{
    public class UserUpdateDTO
    {

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Province is required")]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "City is required")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Suburb is required")]
        public int SuburbId { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string StreetName { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Receive crime email notification option is required")]
        public bool IsEmailNotification { get; set; }
        public bool IsPushNotification { get; set; }

    }
}
