using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assembly.WPF.Models
{
    public class TimeSlot
    {
        [JsonPropertyName("timeSlotId")]
        public int TimeSlotId { get; set; }

        [JsonPropertyName("startTime")]
        public int StartTime { get; set; }

        [JsonPropertyName("endTime")]
        public int EndTime { get; set; }

        [JsonPropertyName("partOfDay")]
        public string PartOfDay { get; set; } = "";

        public override string ToString()
        {
            return $"{StartTime} - {EndTime}";
        }
    }
}
