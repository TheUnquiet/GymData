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
            if (reservation == null) throw new MapException("Reservation does not exist");

            try
            {
                var timeSlots = reservation.ReservationTimeSlotEquipments
                    .Select(rte => new TimeSlotDomain( 
                        rte.TimeSlotId, 
                        rte.TimeSlot.StartTime, 
                        rte.TimeSlot.EndTime, 
                        rte.TimeSlot.PartOfDay)
                    ).ToList();

                var equipment = reservation.ReservationTimeSlotEquipments
                    .Select(rte => new EquipmentDomain(
                        rte.EquipmentId, 
                        rte.Equipment.DeviceType)
                    ).ToList();

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

                reservation.ReservationTimeSlotEquipments = domain.TimeSlots
                    .Zip(domain.Equipment, (timeSlot, equip) => new ReservationTimeSlotEquipment
                    {
                        TimeSlotId = timeSlot.TimeSlotId,
                        EquipmentId = equip.EquipmentId,
                        ReservationId = domain.ReservationId
                    })
                    .ToList();

                return reservation;
            }
            catch (Exception ex)
            {
                throw new MapException($"MapFromDomain, {ex}");
            }
        }
    }
}