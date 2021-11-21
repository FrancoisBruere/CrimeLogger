using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int SuburbId { get; set; }
        public string StreetName { get; set; }

        public DateTime RegistationDate { get; set; }
        public bool IsEmailNotification { get; set; } = false;
        public bool IsPushNotification { get; set; } = false ;

        [Required]
        public bool IsTermsAccepted { get; set; } = false;




    }
}
