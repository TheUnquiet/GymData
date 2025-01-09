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
                var timeSlots = reservation.TimeSlots
                    .Select(ts => TimeSlotMapper.MapToDomain(ts))
                    .ToList();

                var equipment = reservation.Equipment
                    .Select(e => EquipmentMapper.MapToDomain(e))
                    .ToList();

                return new ReservationDomain(
                    reservation.ReservationId,
                    reservation.Date,
                    MemberMapper.MapToDomain(reservation.Member),
                    timeSlots,
                    equipment
                );
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
                var reservation = new Reservation()
                {
                    ReservationId = domain.ReservationId,
                    Date = domain.Date,
                    MemberId = domain.Member.Id
                };

                reservation.TimeSlots = domain.TimeSlots.Select(ts => TimeSlotMapper.MapFromDomain(ts)).ToList();
                reservation.Equipment = domain.Equipment.Select(e => EquipmentMapper.MapFromDomain(e)).ToList();

                return reservation;
            }
            catch (Exception ex)
            {
                throw new MapException($"MapFromDomain, {ex}");
            }
        }
    }
}
