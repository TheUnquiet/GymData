using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Exceptions
{
    public class ProgramCodeDomainException : Exception
    {
        public ProgramCodeDomainException(string? message) : base(message)
        {
        }

        public ProgramCodeDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
