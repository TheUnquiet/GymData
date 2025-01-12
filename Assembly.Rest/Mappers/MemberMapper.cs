using Assembly.Domain.Models;
using Assembly.Rest.Dto.Input;
using Assembly.Rest.Dto.Output;

namespace Assembly.Rest.Mappers
{
    public static class MemberMapper
    {
        public static MemberOutputDto MapToOutputDto(MemberDomain member)
        {
            return new MemberOutputDto
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                Address = member.Address,
                Birthday = member.Birthday,
                Intrest = member.Intressest,
                MemberType = member.MemberType,
                Reservations = member.Reservations.Select(r => new ReservationBasicOutputDto
                {
                    Id = r.ReservationId,
                    ReservationDate = r.Date,
                    TimeSlots = r.TimeSlots.Select(ts => new TimeSlotOutputDto
                    {
                        TimeSlotId = ts.TimeSlotId,
                        StartTime = ts.StartTime,
                        EndTime = ts.EndTime
                    }).ToList(),
                    Equipment = r.Equipment.Select(e => new EquipmentOutputDto
                    {
                        Id = e.EquipmentId,
                        DeviceType = e.DeviceType,
                    }).ToList()
                }).ToList(),
                Programs = member.ProgramCodes.Select(p => new ProgramOutputDto
                {
                    Name = p.Name,
                    ProgramCode = p.ProgramCode,
                    MaxMembers = p.MaxMembers,
                    Target = p.Target,
                    Startdate = p.Startdate,
                }).ToList(),
                RunningSessionDomains = member.RunningsessionMains.Select(rs => RunningSessionMapper.MapToOutputDto(rs)).ToList(),
                CyclingssesionDomains = member.Cyclingssesions.Select(cs => CyclingSessionMapper.MapToOutputDto(cs)).ToList()
            };
        }

        public static MemberDomain MapFromInputDto(MemberInputDto dto)
        {
            return new MemberDomain(dto.FirstName, dto.LastName, dto.Email, dto.Address, dto.Birthday, dto.Intrest, "Bronze");
        }
    }
}
