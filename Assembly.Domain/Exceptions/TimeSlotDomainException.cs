using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Exceptions
{
    public class TimeSlotDomainException : Exception
    {
        public TimeSlotDomainException(string? message) : base(message)
        {
        }

        public TimeSlotDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
