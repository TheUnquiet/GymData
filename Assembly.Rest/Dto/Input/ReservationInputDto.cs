namespace Assembly.Rest.Dto.Input
{
    public class ReservationInputDto
    {
        public DateOnly Date { get; set; }

        public List<int> EquipmentIds { get; set; } = new List<int>();

        public int MemberId { get; set; }

        public List<int> TimeSlotIds { get; set; } = new List<int>();
    }
}
