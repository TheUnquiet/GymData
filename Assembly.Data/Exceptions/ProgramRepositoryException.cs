using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Data.Exceptions
{
    public class ProgramRepositoryException : Exception
    {
        public ProgramRepositoryException(string? message) : base(message)
        {
        }

        public ProgramRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
