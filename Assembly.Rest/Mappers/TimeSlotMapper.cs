using Assembly.Domain.Models;
using Assembly.Rest.Dto.Output;

namespace Assembly.Rest.Mappers
{
    public static class TimeSlotMapper
    {
        public static TimeSlotOutputDto MapToOuputDto(TimeSlotDomain domain)
        {
            return new TimeSlotOutputDto()
            {
                TimeSlotId = domain.TimeSlotId,
                PartOfDay = domain.PartOfDay,
                EndTime = domain.EndTime,
                StartTime = domain.StartTime
            };
        }
    }
}
