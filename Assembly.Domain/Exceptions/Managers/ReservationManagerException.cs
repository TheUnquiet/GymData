﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Exceptions.Managers
{
    public class ReservationManagerException : Exception
    {
        public ReservationManagerException(string? message) : base(message)
        {
        }

        public ReservationManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
