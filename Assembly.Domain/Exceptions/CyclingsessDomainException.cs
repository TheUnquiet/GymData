using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Exceptions
{
    public class CyclingsessDomainException : Exception
    {
        public CyclingsessDomainException(string? message) : base(message)
        {
        }

        public CyclingsessDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
