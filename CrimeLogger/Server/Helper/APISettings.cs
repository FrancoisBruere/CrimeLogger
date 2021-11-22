using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrimeLoggger_Server.Helper
{
    public class APISettings
    {
        public string SecretKey { get; set; }
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
    }
}
