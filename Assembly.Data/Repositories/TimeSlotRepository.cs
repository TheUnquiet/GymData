using Assembly.Data.Data;
using Assembly.Data.Mappers;
using Assembly.Domain.Exceptions;
using Assembly.Domain.Interfaces;
using Assembly.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Data.Repositories
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly GymContext _context;

        public TimeSlotRepository(GymContext context)
        {
            _context = context;
        }

        public async Task<List<TimeSlotDomain>> GetAllTimeSlots()
        {
            try
            {
                return await _context.TimeSlots.Select(t => TimeSlotMapper.MapToDomain(t)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new TimeSlotRepositoryException($"GetAllTimeSlots {ex.Message}");
            }
        }

        public async Task<TimeSlotDomain> GetTimeSlot(int slotId)
        {
            try
            {
                var timeslot = await _context.TimeSlots.Where(r => r.TimeSlotId == slotId).AsNoTracking().FirstOrDefaultAsync();
                if (timeslot != null) return TimeSlotMapper.MapToDomain(timeslot);
                else throw new TimeSlotRepositoryException("Time slot empty");
            }
            catch (Exception ex)
            {
                throw new TimeSlotRepositoryException($"GetTimeSlot: {ex.Message}");
            }
        }
    }
}
