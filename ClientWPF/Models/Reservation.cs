using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.WPF.Models
{
    public class Reservation
    {
        public DateOnly Date { get; set; }

        public int EquipmentId { get; set; }

        public int MemberId { get; set; }

        public int TimeSlotId { get; set; }
    }
}
