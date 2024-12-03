using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Exceptions
{
    public class RunningsessionMainDomainException : Exception
    {
        public RunningsessionMainDomainException(string? message) : base(message)
        {
        }

        public RunningsessionMainDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
