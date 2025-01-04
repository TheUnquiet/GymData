using System;
using System.Collections.Generic;

namespace Assembly.Data.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int EquipmentId { get; set; }

    public int TimeSlotId { get; set; }

    public DateOnly Date { get; set; }

    public int MemberId { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;

    public virtual TimeSlot TimeSlot { get; set; } = null!;
}
