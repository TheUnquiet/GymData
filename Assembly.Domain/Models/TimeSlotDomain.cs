using Assembly.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Models
{
    public class TimeSlotDomain
    {
        #region Constructors

        public TimeSlotDomain(int timeSlotId, int startTime, int endTime,string partOfDay)
        {
            SetId(timeSlotId); 
            SetStartTime(startTime);
            SetEndTime(endTime);
            SetPartOfDay(partOfDay);
        }

        public TimeSlotDomain(int startTime, int endTime, string partOfDay)
        {
            SetStartTime(startTime);
            SetEndTime(endTime);
            SetPartOfDay(partOfDay);
        }

        #endregion

        #region Fields

        public int TimeSlotId { get; set; }

        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public string PartOfDay { get; set; } = "";

        public List<ReservationDomain> Reservations { get; set; } = [];

        #endregion

        #region Methods

        public void SetId(int id)
        {
            if (id <= 0)
            {
                TimeSlotDomainException ex = new TimeSlotDomainException("Id is incorrect");
                ex.Data.Add("id", id);
                throw ex;
            }

            TimeSlotId = id;
        }

        public void SetStartTime(int start)
        {
            if (start <= 0)
            {
                TimeSlotDomainException ex = new TimeSlotDomainException("Start time is incorrect");
                ex.Data.Add("startTime", start);
                throw ex;
            }

            StartTime = start;
        }

        public void SetEndTime(int end)
        {
            if (end <= 0 && end < StartTime)
            {
                TimeSlotDomainException ex = new TimeSlotDomainException("End time is incorrect");
                ex.Data.Add("endTime", end);
                throw ex;
            }

            EndTime = end;
        }

        public void SetPartOfDay(string partOfDay)
        {
            PartOfDay = partOfDay;
        }

        public void AddReservations(ReservationDomain reservation)
        {
            if (reservation == null) throw new TimeSlotDomainException("Reservation is empty");
            if (Reservations.Contains(reservation)) throw new TimeSlotDomainException("Reservation already added");
            Reservations.Add(reservation);
        }

        public void RemoveReservations(ReservationDomain reservation)
        {
            if (reservation == null) throw new TimeSlotDomainException("Reservation is empty");
            if (!Reservations.Contains(reservation)) throw new TimeSlotDomainException("Reservation is not in the list");
            Reservations.Remove(reservation);
        }

        #endregion
    }
}
