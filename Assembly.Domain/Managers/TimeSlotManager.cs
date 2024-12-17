using Assembly.Domain.Exceptions.Managers;
using Assembly.Domain.Interfaces;
using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Managers
{
    public class TimeSlotManager
    {
        private readonly ITimeSlotRepository _repository;

        public TimeSlotManager(ITimeSlotRepository repository)
        {
            _repository = repository;
        }

        public async Task<TimeSlotDomain> GetTimeSlot(int slotId)
        {
            try
            {
                return await _repository.GetTimeSlot(slotId);
            }
            catch (Exception ex)
            {
                throw new TimeSlotManagerException($"GetTimeSlot: {ex.Message}");
            }
        }
    }
}
