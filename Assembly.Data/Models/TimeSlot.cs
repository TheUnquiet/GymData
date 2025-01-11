using System;
using System.Collections.Generic;

namespace Assembly.Data.Models;

public partial class TimeSlot
{
    public int TimeSlotId { get; set; }

    public int StartTime { get; set; }

    public int EndTime { get; set; }

    public string PartOfDay { get; set; } = null!;

    public virtual ICollection<ReservationTimeSlotEquipment> ReservationTimeSlotEquipments { get; set; } = new List<ReservationTimeSlotEquipment>();
}
