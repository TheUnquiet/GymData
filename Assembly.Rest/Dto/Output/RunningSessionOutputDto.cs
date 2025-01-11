namespace Assembly.Rest.Dto.Output
{
    public class RunningSessionOutputDto
    {
        public int RunningSessionId { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set; }

        public double AvgSpeed { get; set; }
    }
}
