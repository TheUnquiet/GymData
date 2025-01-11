using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assembly.WPF.Models
{
    public class Member
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }

        [JsonPropertyName("intrest")]
        public string? Intrest { get; set; }

        [JsonPropertyName("memberType")]
        public string MemberType { get; set; } = string.Empty;

        [JsonPropertyName("reservations")]
        public List<Reservation> Reservations { get; set; } = [];

        [JsonPropertyName("programs")]
        public List<Programs> Programs { get; set; } = [];

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
