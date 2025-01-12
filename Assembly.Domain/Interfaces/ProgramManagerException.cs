using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Interfaces
{
    public class ProgramManagerException : Exception
    {
        public ProgramManagerException(string message) : base(message)
        {
        }

        public ProgramManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
