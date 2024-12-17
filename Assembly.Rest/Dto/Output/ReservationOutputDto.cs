using Assembly.Domain.Models;

namespace Assembly.Rest.Dto.Output
{
    public class ReservationOutputDto
    {
        public DateOnly Date { get; set; }

        public EquipmentOutputDto Equipment { get; set; } = null!;

        public MemberOutputDto Member { get; set; } = null!;
    }
}
