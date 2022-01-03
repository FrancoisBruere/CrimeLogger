using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeLogger.Shared
{
    public class CrimeDetailDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please select a Province")]
        public int? Province_Id { get; set; }

        [Required(ErrorMessage = "Please select a City")]
        public int? City_Id { get; set; }

        [Required(ErrorMessage = "Please select a Suburb")]
        public int? Suburb_Id { get; set; }

        [Required(ErrorMessage = "Please enter a Street Name")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please select the closest mathing Crime Type")]
        public int? CrimeType_Id { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the date the crime took place")]
        public DateTime? CrimeDate { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Please acknowledge that the above crime details entered is valid and correct")]
        public bool IsTrueCrime { get; set; }
        public bool IsMarkerAdded { get; set; } = false;
        public double MyLat { get; set; }
        public double MyLng { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

       

    }
}
