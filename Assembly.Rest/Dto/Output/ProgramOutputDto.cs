namespace Assembly.Rest.Dto.Output
{
    public class ProgramOutputDto
    {
        public string ProgramCode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Target { get; set; } = string.Empty;

        public DateTime Startdate { get; set; }

        public int MaxMembers { get; set; }
    }
}
