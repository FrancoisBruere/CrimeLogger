﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class SD
    {
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";
        public const string Role_User = "User";
        public const string Role_Customer = "Customer";

        public const string Local_Token = "JWT Token";
        public const string Local_UserDetails = "User Details";
        public const int TokenLifeInDays = 1;
    }
}