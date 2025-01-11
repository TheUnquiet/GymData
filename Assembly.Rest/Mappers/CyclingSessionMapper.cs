using Assembly.Domain.Models;
using Assembly.Rest.Dto.Output;

namespace Assembly.Rest.Mappers
{
    public static class CyclingSessionMapper
    {
        public static CyclingSessionOutputDto MapToOutputDto(CyclingssesionDomain domain)
        {
            return new CyclingSessionOutputDto
            {
                CyclingSessionId = domain.CyclingsessionId,
                Date = domain.Date,
                Duration = domain.Duration,
                AvgWatt = domain.AvgWatt,
                MaxWatt = domain.MaxWatt,
                AvgCadence = domain.AvgCadence,
                MaxCadence = domain.MaxCadence,
                TrainingType = domain.Trainingtype,
                Comment = domain.Comment
            };
        }

        //public static CyclingssesionDomain MapFromInputDto(CyclingSessionInputDto dto, MemberDomain member)
        //{
        //    return new CyclingssesionDomain
        //    {
        //        CyclingsessionId = dto.CyclingSessionId,
        //        Date = dto.Date,
        //        Duration = dto.Duration,
        //        AvgWatt = dto.AvgWatt,
        //        MaxWatt = dto.MaxWatt,
        //        AvgCadence = dto.AvgCadence,
        //        MaxCadence = dto.MaxCadence,
        //        Trainingtype = dto.TrainingType,
        //        Comment = dto.Comment,
        //        Member = member
        //    };
        //}
    }
}
