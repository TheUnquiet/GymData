using Assembly.Domain.Exceptions;

namespace Assembly.Domain.Models
{
    public class RunningsessionMainDomain
    {
        #region Constructors

        public RunningsessionMainDomain(int runningsessionId, DateTime date, int duration, double avgSpeed, MemberDomain member)
        {
            SetId(runningsessionId);
            SetDate(date);
            SetDuration(duration);
            SetAvgSpeed(avgSpeed);
            SetMember(member);
        }

        public RunningsessionMainDomain(DateTime date, int duration, double avgSpeed, MemberDomain member)
        {
            SetDate(date);
            SetDuration(duration);
            SetAvgSpeed(avgSpeed);
            SetMember(member);
        }

        #endregion

        #region Fields

        public int RunningsessionId { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set; }

        public double AvgSpeed { get; set; }

        public MemberDomain? Member { get; set; } = null!;

        public List<RunningsessionDetailDomain> RunningsessionDetails { get; set; } = [];

        #endregion

        #region Methods

        public void SetId(int id)
        {
            if (id <= 0)
            {
                RunningsessionMainDomainException ex = new RunningsessionMainDomainException("Id is incorrect");
                ex.Data.Add("id", id);
                throw ex;
            }

            RunningsessionId = id;
        }

        public void SetDate(DateTime date)
        {
            Date = date;
        }

        public void SetDuration(int duration)
        {
            if (duration <= 0)
            {
                RunningsessionMainDomainException ex = new RunningsessionMainDomainException("Duration is incorrect");
                ex.Data.Add("duration", duration);
                throw ex;
            }

            Duration = duration;
        }

        public void SetAvgSpeed(double avgSpeed)
        {
            if (avgSpeed <= 0)
            {
                RunningsessionMainDomainException ex = new RunningsessionMainDomainException("Avg speed is incorrect");
                ex.Data.Add("avgSpeed", avgSpeed);
                throw ex;
            }

            AvgSpeed = avgSpeed;
        }

        public void SetMember(MemberDomain member)
        {
            if (member == null) throw new RunningsessionMainDomainException("Member is empty");
            if (member == Member) throw new RunningsessionMainDomainException("Member already set");
            Member = member;
        }

        public void AddDetail(RunningsessionDetailDomain detail)
        {
            if (detail == null) throw new RunningsessionMainDomainException("Detail is empty");
            if (RunningsessionDetails.Contains(detail)) throw new RunningsessionMainDomainException("Detail is already in the list");
            RunningsessionDetails.Add(detail);
        }

        public void RemoveDetail(RunningsessionDetailDomain detail)
        {
            if (detail == null) throw new RunningsessionMainDomainException("Detail is empty");
            if (!RunningsessionDetails.Contains(detail)) throw new RunningsessionMainDomainException("Detail is not in the list");
            RunningsessionDetails.Remove(detail);
        }

        #endregion
    }
}