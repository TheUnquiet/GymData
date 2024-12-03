using Assembly.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Models
{
    public class RunningsessionDetailDomain
    {
        #region Fields

        public int SeqNr { get; set; }

        public int IntervalTime { get; set; }

        public double IntervalSpeed { get; set; }

        public RunningsessionMainDomain Runningsession { get; set; } = null!;

        #endregion

        #region Constructors

        public void SetseqNr(int seqNr)
        {
            if (seqNr <= 0)
            {
                RunningsessionDetailDomainException ex = new RunningsessionDetailDomainException("SeqNr is incorrect");
                ex.Data.Add("seqnr", seqNr);
                throw ex;
            }

            SeqNr = seqNr;
        }

        public void SetIntervalTime(int intervalTime)
        {
            if (intervalTime <= 0)
            {
                RunningsessionDetailDomainException ex = new RunningsessionDetailDomainException("IntervalTime is incorrect");
                ex.Data.Add("intervalTime", intervalTime);
                throw ex;
            }

            IntervalTime = intervalTime;
        }

        #endregion
    }
}
