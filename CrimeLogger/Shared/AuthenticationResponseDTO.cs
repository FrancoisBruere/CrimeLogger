﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeLogger.Shared
{
    public class AuthenticationResponseDTO
    {
        public bool isAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }

        public string Token { get; set; }
        public UserDTO UserDTO { get; set; }

    }
}
