using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Data.Exceptions
{
    public class EquipmentRepositoryException : Exception
    {
        public EquipmentRepositoryException(string? message) : base(message)
        {
        }

        public EquipmentRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
