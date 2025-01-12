using Assembly.Domain.Models;

namespace Assembly.Rest.Dto.Output
{
    public class MemberOutputDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateOnly Birthday { get; set; }

        public string Intrest { get; set; } = string.Empty;

        public string MemberType { get; set; } = string.Empty;

        public List<ReservationBasicOutputDto> Reservations { get; set; } = [];

        public List<ProgramOutputDto> Programs { get; set; } = [];

        public List<CyclingSessionOutputDto> CyclingssesionDomains { get; set; } = [];

        public List<RunningSessionOutputDto> RunningSessionDomains { get; set; } = [];
    }
}
