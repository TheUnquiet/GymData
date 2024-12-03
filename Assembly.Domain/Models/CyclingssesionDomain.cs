using Assembly.Domain.Enums;
using Assembly.Domain.Exceptions;

namespace Assembly.Domain.Models
{
    public class CyclingssesionDomain
    {
        #region Constructor

        public CyclingssesionDomain()
        {
        }

        public CyclingssesionDomain(int cyclingsessionId, DateTime date, int duration, int avgWatt, int maxWatt, int avgCadence, int maxCadence, TrainingTypeDomain trainingtype, string? comment, MemberDomain member)
        {
            SetId(cyclingsessionId);
            SetDate(date);
            SetDuration(duration);
            SetAvgWatt(avgWatt);
            SetMaxWatt(maxWatt);
            SetAvgCadence(avgCadence);
            SetMaxCadence(maxCadence);
            SetTrainingsType(trainingtype);
            SetComment(comment);
            SetMember(member);
        }

        public CyclingssesionDomain(DateTime date, int duration, int avgWatt, int maxWatt, int avgCadence, int maxCadence, TrainingTypeDomain trainingtype, string? comment, MemberDomain member)
        {
            Date = date;
            Duration = duration;
            AvgWatt = avgWatt;
            MaxWatt = maxWatt;
            AvgCadence = avgCadence;
            MaxCadence = maxCadence;
            Trainingtype = trainingtype;
            Comment = comment;
            Member = member;
        }

        #endregion

        #region Fields

        public int CyclingsessionId { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set; }

        public int AvgWatt { get; set; }

        public int MaxWatt { get; set; }

        public int AvgCadence { get; set; }

        public int MaxCadence { get; set; }

        public TrainingTypeDomain Trainingtype { get; set; }

        public string? Comment { get; set; }

        public MemberDomain Member { get; set; } = null!;

        #endregion

        #region Methods

        public void SetId(int id)
        {
            if (id <= 0)
            {
                CyclingsessDomainException ex = new("Id is incorrect : ");
                ex.Data.Add("Id", id);
                throw ex;
            }

            CyclingsessionId = id;
        }

        public void SetDate(DateTime date)
        {
            Date = date;
        }

        public void SetDuration(int duration)
        {
            if (duration <= 0)
            {
                CyclingsessDomainException ex = new("Duration is incorrect : ");
                ex.Data.Add("Duration", duration);
                throw ex;
            }

            CyclingsessionId = duration;
        }

        public void SetAvgWatt(int avg)
        {
            if (avg <= 0)
            {
                CyclingsessDomainException ex = new("AvgWatt is incorrect : ");
                ex.Data.Add("AvgWatt", avg);
                throw ex;
            }

            AvgWatt = avg;
        }

        public void SetMaxWatt(int maxWatt)
        {
            if (maxWatt <= 0)
            {
                CyclingsessDomainException ex = new("MaxWatt is incorrect : ");
                ex.Data.Add("MaxWatt", maxWatt);
                throw ex;
            }

            MaxWatt = maxWatt;
        }

        public void SetAvgCadence(int avgCadence)
        {
            if (avgCadence <= 0)
            {
                CyclingsessDomainException ex = new("AvgCadence is incorrect : ");
                ex.Data.Add("avgCadence", avgCadence);
                throw ex;
            }

            AvgCadence = avgCadence;
        }

        public void SetMaxCadence(int maxCadence)
        {
            if (maxCadence <= 0)
            {
                CyclingsessDomainException ex = new("MAxCadence is incorrect : ");
                ex.Data.Add("maxCadence", maxCadence);
                throw ex;
            }

            MaxCadence = maxCadence;
        }

        public void SetTrainingsType(TrainingTypeDomain trainingType)
        {
            Trainingtype = trainingType;
        }

        public void SetComment(string? comment)
        {
            Comment = comment;
        }

        public void SetMember(MemberDomain member)
        {
            if (member == null) throw new CyclingsessDomainException("Member is empty");
            Member = member;
        }

        #endregion
    }
}