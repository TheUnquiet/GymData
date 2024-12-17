using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Exceptions
{
    public class TimeSlotRepositoryException : Exception
    {
        public TimeSlotRepositoryException(string? message) : base(message)
        {
        }

        public TimeSlotRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
