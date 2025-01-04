using System;
using System.Collections.Generic;

namespace Assembly.Data.Models;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public string DeviceType { get; set; } = null!;
}
