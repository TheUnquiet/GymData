using Assembly.Data.Exceptions.Mappers;
using Assembly.Data.Models;
using Assembly.Domain.Enums;
using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Data.Mappers
{
    public class RunningsessionMainMapper
    {
        public static RunningsessionMainDomain MapToDomain(RunningsessionMain runningsessionMain)
        {
            try
            {
                return new RunningsessionMainDomain(runningsessionMain.RunningsessionId, runningsessionMain.Date, runningsessionMain.Duration, runningsessionMain.AvgSpeed, MemberMapper.MapToDomain(runningsessionMain.Member));
            }
            catch (Exception ex)
            {
                throw new MapException("MapToDomain", ex);
            }
        }

        public static RunningsessionMain MapFromDomain(RunningsessionMainDomain domain)
        {
            try
            {
                return new RunningsessionMain()
                {
                    RunningsessionId = domain.RunningsessionId,
                    Date = domain.Date,
                    Duration = domain.Duration,
                    AvgSpeed = domain.AvgSpeed,
                    Member = MemberMapper.MapFromDomain(domain.Member),
                };
            }
            catch (Exception ex)
            {
                throw new MapException("MapFromDomain", ex);
            }
        }
    }
}
