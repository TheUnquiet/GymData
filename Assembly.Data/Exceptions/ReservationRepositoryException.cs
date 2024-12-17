using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Data.Exceptions
{
    public class ReservationRepositoryException : Exception
    {
        public ReservationRepositoryException(string? message) : base(message)
        {
        }

        public ReservationRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
