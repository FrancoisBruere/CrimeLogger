using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class CrimeType
    {
        [Key]
        public int CrimeId { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
