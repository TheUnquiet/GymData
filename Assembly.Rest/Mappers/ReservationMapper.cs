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
                Id = reservation.ReservationId,
                ReservationDate = reservation.Date,
                TimeSlots = reservation.TimeSlots.Select(t => TimeSlotMapper.MapToOuputDto(t)).ToList(),
                Equipment = reservation.Equipment.Select(e => EquipmentMapper.MapToOutputDto(e)).ToList()
            };
        }

        public static ReservationBasicOutputDto MapToBasicOuputDto(ReservationDomain reservation)
        {
            return new ReservationBasicOutputDto()
            {
                Id = reservation.ReservationId,
                ReservationDate = reservation.Date,
                TimeSlots = reservation.TimeSlots.Select(t => TimeSlotMapper.MapToOuputDto(t)).ToList(),
                Equipment = reservation.Equipment.Select(e => EquipmentMapper.MapToOutputDto(e)).ToList()
            };
        }
    }
}
