using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Exceptions.Managers
{
    public class TimeSlotManagerException : Exception
    {
        public TimeSlotManagerException(string? message) : base(message)
        {
        }

        public TimeSlotManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
