using Assembly.Data.Exceptions;
using Assembly.Data.Exceptions.Mappers;
using Assembly.Data.Models;
using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Data.Mappers;

public static class MemberMapper
{
    public static MemberDomain MapToDomain(Member member)
    {
        try
        {
            var memberDomain = new MemberDomain(
                member.FirstName,
                member.LastName,
                member.Email,
                member.Address,
                member.Birthday,
                member.Interests,
                member.Membertype,
                new List<ReservationDomain>(), // Initialize with an empty list
                member.ProgramCodes.Select(ProgramCodesMapper.MapToDomain).ToList(),
                new List<RunningsessionMainDomain>(), // Initialize with an empty list
                new List<CyclingssesionDomain>()
            );

            memberDomain.Reservations = member.Reservations.Select(r => new ReservationDomain(
                r.ReservationId,
                r.Date,
                memberDomain, // Set the member reference here
                r.ReservationTimeSlotEquipments.Select(rte => new TimeSlotDomain(
                    rte.TimeSlotId,
                    rte.TimeSlot.StartTime,
                    rte.TimeSlot.EndTime,
                    rte.TimeSlot.PartOfDay)).ToList(),
                r.ReservationTimeSlotEquipments.Select(rte => new EquipmentDomain(
                    rte.EquipmentId,
                    rte.Equipment.DeviceType)).ToList())).ToList();

            memberDomain.RunningsessionMains = member.RunningsessionMains.Select(rs => new RunningsessionMainDomain(
                rs.RunningsessionId,
                rs.Date,
                rs.Duration,
                rs.AvgSpeed,
                memberDomain)).ToList();

            memberDomain.Cyclingssesions = member.Cyclingsessions.Select(cs => new CyclingssesionDomain(
                cs.CyclingsessionId,
                cs.Date,
                cs.Duration,
                cs.AvgWatt,
                cs.MaxWatt,
                cs.AvgCadence,
                cs.MaxCadence,
                cs.Trainingtype,
                cs.Comment,
                memberDomain)).ToList();

            return memberDomain;
        }
        catch (Exception ex)
        {
            throw new MapException("MemberMapper - MapToDomain", ex);
        }
    }

    public static Member MapFromDomain(MemberDomain member)
    {
        try
        {
            return new Member()
            {
                MemberId = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                Address = member.Address,
                Birthday = member.Birthday,
                Interests = member.Intressest,
                Membertype = member.MemberType,
                Cyclingsessions = member.Cyclingssesions.Select(CyclingsessionMapper.MapFromDomain).ToList(),
                ProgramCodes = member.ProgramCodes.Select(ProgramCodesMapper.MapFromDomain).ToList(),
                Reservations = member.Reservations.Select(r => new Reservation()
                {
                    ReservationId = r.ReservationId,
                    Date = r.Date,
                    MemberId = member.Id, // Avoid circular reference
                    ReservationTimeSlotEquipments = r.TimeSlots.Zip(r.Equipment, (timeSlot, equip) => new ReservationTimeSlotEquipment
                    {
                        TimeSlotId = timeSlot.TimeSlotId,
                        EquipmentId = equip.EquipmentId,
                        ReservationId = r.ReservationId
                    }).ToList()
                }).ToList(),
                RunningsessionMains = member.RunningsessionMains.Select(RunningsessionMainMapper.MapFromDomain).ToList(),
            };
        }
        catch (Exception ex)
        {
            throw new MapException("MemberMapper - MapFromDomain", ex);
        }
    }
}
