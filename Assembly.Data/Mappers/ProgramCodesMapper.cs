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
    public static class ProgramCodesMapper
    {
        public static ProgramDomain MapToDomain(Program program)
        {
            try
            { 
                return new ProgramDomain(program.ProgramCode, program.Name, program.Target, program.Startdate, program.MaxMembers); 
            }
            catch (Exception ex)
            {
                throw new MapException($"MapToDomain, {ex}");
            }
        }

        public static Program MapFromDomain(ProgramDomain domain)
        {
            try
            {
                return new Program()
                {
                    ProgramCode = domain.ProgramCode,
                    Name = domain.Name,
                    Target = domain.Target,
                    Startdate = domain.Startdate,
                    MaxMembers = domain.MaxMembers
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"MapFromDomain, {ex}");
            }
        }
    }
}
