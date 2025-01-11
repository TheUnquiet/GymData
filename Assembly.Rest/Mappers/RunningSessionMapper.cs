using Assembly.Domain.Models;
using Assembly.Rest.Dto.Output;

namespace Assembly.Rest.Mappers
{
    public static class RunningSessionMapper
    {
        public static RunningSessionOutputDto MapToOutputDto(RunningsessionMainDomain session)
        {
            return new RunningSessionOutputDto
            {
                RunningSessionId = session.RunningsessionId,
                Date = session.Date,
                Duration = session.Duration,
                AvgSpeed = session.AvgSpeed
            };
        }
    }
}
