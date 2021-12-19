using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class CrimeProvince
    {
        [Key]
        public int ProvinceId { get; set; }
        [Required]
        public string Name { get; set; }

    

    }
}
