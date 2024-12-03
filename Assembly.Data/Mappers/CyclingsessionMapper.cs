using Assembly.Data.Exceptions;
using Assembly.Data.Exceptions.Mappers;
using Assembly.Data.Models;
using Assembly.Domain.Enums;
using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assembly.Data.Mappers
{
    public static class CyclingsessionMapper
    {
        public static CyclingssesionDomain MapToDomain(Cyclingsession session)
        {
            try
            {
                return new CyclingssesionDomain(session.CyclingsessionId, session.Date, session.Duration, session.AvgWatt, session.MaxWatt, session.AvgCadence, session.MaxCadence, (TrainingTypeDomain)Enum.Parse(typeof(TrainingTypeDomain), session.Trainingtype), session.Comment, MemberMapper.MapToDomain(session.Member));
            }
            catch (Exception ex)
            {
                throw new MapException($"MapToDomain {ex}");
            }
        }

        public static Cyclingsession MapFromDomain(CyclingssesionDomain session)
        {
            try
            {
                return new Cyclingsession()
                {
                    CyclingsessionId = session.CyclingsessionId,
                    Date = session.Date,
                    Duration = session.Duration,
                    AvgWatt = session.AvgWatt,
                    MaxWatt = session.MaxWatt,
                    AvgCadence = session.AvgCadence,
                    MaxCadence = session.MaxCadence,
                    Trainingtype = session.Trainingtype.ToString(),
                    Comment = session.Comment,
                    Member = MemberMapper.MapFromDomain(session.Member),
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"MapFromDomain {ex}");
            }
        }
    }
}
