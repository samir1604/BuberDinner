﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Contracts.Authentication
{
    public record AuthenticationResponse
    {
        public Guid Id;
        public string FirstName;
        public string LastName;
        public string Email;
        public string Token;
    }
}
