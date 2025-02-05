﻿using Assembly.Domain.Models;

namespace Assembly.Rest.Dto.Output
{
    public class ReservationOutputDto
    {
        public int Id { get; set; }

        public DateOnly ReservationDate { get; set; }

        public List<TimeSlotOutputDto> TimeSlots { get; set; } = [];

        public List<EquipmentOutputDto> Equipment { get; set; } = [];
    }
}
