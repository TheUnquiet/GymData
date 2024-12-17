using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Interfaces
{
    public interface ITimeSlotRepository
    {
        Task<TimeSlotDomain> GetTimeSlot(int slotId);
        Task<List<TimeSlotDomain>> GetAllTimeSlots();
    }
}
