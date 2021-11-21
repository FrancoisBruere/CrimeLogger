using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationUser :IdentityUser
    {
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int SuburbId { get; set; }
        public string StreetName { get; set; }

        public bool IsEmailNotification { get; set; }
        public bool IsPushNotification { get; set; }
        public bool IsTermsAccepted { get; set; }

    }
}
