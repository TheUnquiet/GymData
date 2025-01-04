namespace Assembly.Rest.Dto.Input
{
    public class ReservationInputDto
    {
        public DateOnly Date { get; set; }

        public int EquipmentId { get; set; }

        public int MemberId { get; set; }

        public int TimeSlotId { get; set; }
    }
}
