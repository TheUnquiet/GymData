using Assembly.Domain.Exceptions;

namespace Assembly.Domain.Models
{
    public class ProgramDomain
    {
        #region Constructors

        public ProgramDomain(string programCode, string name, string target, DateTime startdate, int maxMembers)
        {
            SetProgramCode(programCode);
            SetName (name);
            SetTarget(target);
            SetStartDate(startdate);
            SetMaxMembers(maxMembers);
        }

        #endregion

        #region Fields

        public string ProgramCode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Target { get; set; } = string.Empty;

        public DateTime Startdate { get; set; }

        public int MaxMembers { get; set; }

        public virtual List<MemberDomain> Members { get; set; } = [];

        #endregion

        #region Methods

        public void SetProgramCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                ProgramCodeDomainException ex = new ProgramCodeDomainException("Code is incorrect");
                ex.Data.Add("Code", code);
                throw ex;
            }

            ProgramCode = code;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ProgramCodeDomainException ex = new ProgramCodeDomainException("Name is incorrect");
                ex.Data.Add("Name", name);
                throw ex;
            }

            Name = name;
        }

        public void SetTarget(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                ProgramCodeDomainException ex = new ProgramCodeDomainException("Target is incorrect");
                ex.Data.Add("Target", target);
                throw ex;
            }

            Target = target;
        }

        public void SetStartDate(DateTime startDate)
        {
            Startdate = startDate;
        }

        public void SetMaxMembers(int maxMembers)
        {
            MaxMembers = maxMembers;
        }

        public void AddMember(MemberDomain member)
        {
            if (member == null) throw new ProgramCodeDomainException("Member is empty");
            if (Members.Contains(member)) throw new ProgramCodeDomainException("Member already added");
            if (Members.Count == MaxMembers) throw new ProgramCodeDomainException("Program full");
            Members.Add(member);
        }

        public void RemoveMember(MemberDomain member)
        {
            if (member == null) throw new ProgramCodeDomainException("Member is empty");
            if (!Members.Contains(member)) throw new ProgramCodeDomainException("Member not in the list");
            Members.Remove(member);
        }

        #endregion
    }
}