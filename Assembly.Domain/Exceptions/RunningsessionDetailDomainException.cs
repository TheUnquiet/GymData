using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Exceptions
{
    public class RunningsessionDetailDomainException : Exception
    {
        public RunningsessionDetailDomainException(string? message) : base(message)
        {
        }

        public RunningsessionDetailDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
