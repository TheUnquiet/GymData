using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Exceptions.Managers
{
    public class EquipmentManagerException : Exception
    {
        public EquipmentManagerException(string? message) : base(message)
        {
        }

        public EquipmentManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
