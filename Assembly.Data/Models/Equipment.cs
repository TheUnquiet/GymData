using System;
using System.Collections.Generic;

namespace Assembly.Data.Models;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public string DeviceType { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
