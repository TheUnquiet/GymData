namespace Assembly.Rest.Dto.Input
{
    public class MemberInputDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateOnly Birthday { get; set; }

        public string Intrest { get; set; } = string.Empty;
    }
}
