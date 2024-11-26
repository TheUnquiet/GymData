using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Exceptions
{
    public class MemberDomainException : Exception
    {
        public MemberDomainException(string? message) : base(message)
        {
        }

        public MemberDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
