using Assembly.Domain.Models;
using Assembly.Rest.Dto.Input;
using Assembly.Rest.Dto.Output;

namespace Assembly.Rest.Mappers
{
    public static class ReservationMapper
    {
        public static ReservationOutputDto MapToOutputDto(ReservationDomain reservation)
        {
            return new ReservationOutputDto()
            {
                Date = reservation.Date,
                Member = MemberMapper.MapToOutputDto(reservation.Member),
            };
        }
    }
}
