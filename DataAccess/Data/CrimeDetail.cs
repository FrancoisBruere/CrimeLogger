using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class CrimeDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Province_Id { get; set; }

        [Required]
        public int City_Id { get; set; }

        [Required]
        public int Suburb_Id { get; set; }

        public string Street { get; set; }

        [Required]
        public int CrimeType_Id { get; set; }

        public string Description { get; set; }

        public DateTime CrimeDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public bool IsTrueCrime { get; set; }
        public bool IsMarkerAdded { get; set; }
        public double MyLat { get; set; }
        public double MyLng { get; set; }



    }
}
