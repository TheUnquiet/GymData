using System;
using System.Collections.Generic;

namespace Assembly.Data.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public DateOnly Date { get; set; }

    public int MemberId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<ReservationTimeSlotEquipment> ReservationTimeSlotEquipments { get; set; } = new List<ReservationTimeSlotEquipment>();
}
