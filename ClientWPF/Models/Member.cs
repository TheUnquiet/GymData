﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assembly.WPF.Models
{
    public class Member
    {
        [JsonPropertyName("id")]
        public int MemberId { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("birthday")]
        public DateOnly Birthday { get; set; }

        [JsonPropertyName("intrest")]
        public string? Intrest { get; set; }

        [JsonPropertyName("memberType")]
        public string MemberType { get; set; } = string.Empty;

        [JsonPropertyName("reservations")]
        public List<Reservation> Reservations { get; set; } = [];

        [JsonPropertyName("programs")]
        public List<ProgramModel> Programs { get; set; } = [];

        [JsonPropertyName("cyclingssesionDomains")]
        public List<CyclingSession> CyclingssesionDomains { get; set; } = [];

        [JsonPropertyName("runningSessionDomains")]
        public List<RunningSession> RunningSessionDomains { get; set; } = [];

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
