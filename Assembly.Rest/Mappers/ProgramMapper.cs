using Assembly.Domain.Models;
using Assembly.Rest.Dto.Input;
using Assembly.Rest.Dto.Output;

namespace Assembly.Rest.Mappers
{
    public static class ProgramMapper
    {
        public static ProgramOutputDto MapProgramToOutputDto(ProgramDomain program)
        {
            return new ProgramOutputDto
            {
                ProgramCode = program.ProgramCode,
                Name = program.Name,
                Target = program.Target,
                Startdate = program.Startdate,
                MaxMembers = program.MaxMembers
            };
        }

        public static ProgramDomain MapProgramToDomain(ProgramInputDto program)
        {
            return new ProgramDomain(program.ProgramCode, program.Name, program.Target, program.Startdate, program.MaxMembers);
        }

        public static ProgramDomain MapInputProgramToDomain(ProgramInputDto program)
        {
            return new ProgramDomain(program.ProgramCode, program.Name, program.Target, program.Startdate, program.MaxMembers);
        }
    }
}
