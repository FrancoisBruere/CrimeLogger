using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class CrimeCity
    {
        [Key]
        public int CityId { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; }

        [ForeignKey("ProvinceId")]
        public CrimeProvince CrimeProvince { get; set; }


    }
}
