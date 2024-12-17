using Assembly.Domain.Enums;

namespace Assembly.Rest.Dto.Output
{
    public class TimeSlotOutputDto
    {
        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public PartOfDayDomain PartOfDay { get; set; }
    }
}
