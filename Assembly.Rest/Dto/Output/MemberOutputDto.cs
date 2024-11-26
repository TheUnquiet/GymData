using Assembly.Domain.Models;

namespace Assembly.Rest.Dto.Output
{
    public class MemberOutputDto
    {
        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateOnly Birthday { get; set; }

        public string Intrest { get; set; } = string.Empty;

        public MemberTypeDomain MemberType { get; set; }
    }
}
