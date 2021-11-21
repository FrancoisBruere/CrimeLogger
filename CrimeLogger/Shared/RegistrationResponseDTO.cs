using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeLogger.Shared
{
    public class RegistrationResponseDTO
    {

        public bool isRegistrationSuccessful { get; set; }

        public IEnumerable<string> Errors { get; set; }


    }
}
