using System.Text.Json.Serialization;

namespace Assembly.WPF.Models
{
    public class CyclingSession
    {
        [JsonPropertyName("cyclingSessionId")]
        public int CyclingSessionId { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("avgWatt")]
        public int AvgWatt { get; set; }

        [JsonPropertyName("maxWatt")]
        public int MaxWatt { get; set; }

        [JsonPropertyName("avgCadence")]
        public int AvgCadence { get; set; }

        [JsonPropertyName("maxCadence")]
        public int MaxCadence { get; set; }

        [JsonPropertyName("trainingType")]
        public string TrainingType { get; set; } = "";

        [JsonPropertyName("comment")]
        public string? Comment { get; set; }

        public override string ToString()
        {
            return $"{CyclingSessionId} {Date} {TrainingType}";
        }
    }
}