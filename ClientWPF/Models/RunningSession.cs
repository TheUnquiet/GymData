using System.Text.Json.Serialization;

namespace Assembly.WPF.Models
{
    public class RunningSession
    {
        [JsonPropertyName("runningSessionId")]
        public int RunningSessionId { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("avgSpeed")]
        public double AvgSpeed { get; set; }

        public override string ToString()
        {
            return $"{RunningSessionId} {Date} {AvgSpeed}";
        }
    }
}