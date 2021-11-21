using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class CrimeSuburb
    {

        [Key]
        public int SuburbId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }

        [ForeignKey("CityId")]
        public CrimeCity CrimeCity { get; set; }
    }

}
