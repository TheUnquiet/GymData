namespace Assembly.Rest.Dto.Output
{
    public class TimeSlotOutputDto
    {
        public int TimeSlotId { get; set; }

        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public string PartOfDay { get; set; } = "";
    }
}
