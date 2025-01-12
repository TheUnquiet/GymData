using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assembly.WPF.Models
{
    public class ProgramModel
    {
        [JsonPropertyName("programCode")]
        public string ProgramCode { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("target")]
        public string Target { get; set; } = "";

        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("maxMembers")]
        public int MaxMembers { get; set; }

        public override string ToString()
        {
            return $"{ProgramCode} - {Name} - {StartDate} - {Target}";
        }
    }
}
