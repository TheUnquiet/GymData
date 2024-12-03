using Assembly.Data.Exceptions.Mappers;
using Assembly.Data.Models;
using Assembly.Domain.Enums;
using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Data.Mappers
{
    public static class TimeSlotMapper
    {
        public static TimeSlotDomain MapToDomain(TimeSlot timeSlot)
        {
            try
            {
                return new TimeSlotDomain(timeSlot.TimeSlotId, timeSlot.StartTime, timeSlot.EndTime, (PartOfDayDomain)Enum.Parse(typeof(PartOfDayDomain), timeSlot.PartOfDay));
            }
            catch (Exception ex)
            {
                throw new MapException($"MapToDomain, {ex}");
            }
        }

        public static TimeSlot MapFromDomain(TimeSlotDomain domain)
        {
            try
            {
                return new TimeSlot()
                {
                    TimeSlotId = domain.TimeSlotId,
                    StartTime = domain.StartTime,
                    EndTime = domain.EndTime,
                    PartOfDay = domain.PartOfDay.ToString()
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"MapFromDomain, {ex}");
            }
        }
    }
}
