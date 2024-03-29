﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Errors
{
    public class DuplicateEmailException : Exception, IServiceException
    {
        public DuplicateEmailException(string? message) : base(message)
        {
        }

        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Email already exists";
    }
}
