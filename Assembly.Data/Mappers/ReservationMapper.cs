using Assembly.Data.Exceptions.Mappers;
using Assembly.Data.Models;
using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Data.Mappers
{
    public static class ReservationMapper
    {

        public static ReservationDomain MapToDomain(Reservation reservation)
        {
            try
            {
                return new ReservationDomain(reservation.ReservationId, reservation.Date, EquipmentMapper.MapToDomain(reservation.Equipment), MemberMapper.MapToDomain(reservation.Member), TimeSlotMapper.MapToDomain(reservation.TimeSlot));
            }
            catch (Exception ex)
            {
                throw new MapException($"MapToDomain, {ex}");
            }
        }

        public static Reservation MapFromDomain(ReservationDomain domain)
        {
            try
            {
                return new Reservation()
                {
                    ReservationId = domain.ReservationId,
                    Date = domain.Date,
                    EquipmentId = domain.Equipment.EquipmentId,
                    MemberId = domain.Member.Id,
                    TimeSlotId = domain.TimeSlot.TimeSlotId
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"MapFromDomain, {ex}");
            }
        }
    }
}
