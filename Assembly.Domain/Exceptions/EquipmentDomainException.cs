using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Exceptions
{
    public class EquipmentDomainException : Exception
    {
        public EquipmentDomainException(string? message) : base(message)
        {
        }

        public EquipmentDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
