using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assembly.WPF.Models
{    public class Reservation
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("reservationDate")]
        public DateOnly ReservationDate { get; set; }

        [JsonPropertyName("memberOutputDto")]
        public Member Member { get; set; } = null!;

        [JsonPropertyName("timeSlots")]
        public List<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();

        [JsonPropertyName("equipment")]
        public List<Equipment> Equipment { get; set; } = new List<Equipment>();
    }

}
