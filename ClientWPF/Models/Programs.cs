using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assembly.WPF.Models
{
    public class Programs
    {
        [JsonPropertyName("programCode")]
        public string ProgramCode { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("target")]
        public string Target { get; set; } = string.Empty;

        [JsonPropertyName("startdate")]
        public DateTime Startdate { get; set; }

        [JsonPropertyName("maxMembers")]
        public int MaxMembers { get; set; }

        public override string ToString()
        {
            return $"{ProgramCode} {Name} {Startdate} {Target}";
        }
    }
}
