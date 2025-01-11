using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assembly.WPF.Models
{
    public class Equipment
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("deviceType")]
        public string DeviceType { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Id} {DeviceType}";
        }
    }
}
