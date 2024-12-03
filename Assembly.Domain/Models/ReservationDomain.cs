using Assembly.Domain.Exceptions;

namespace Assembly.Domain.Models
{
    public class ReservationDomain
    {
        #region Constructors

        public ReservationDomain(int reservationId, DateOnly date, EquipmentDomain equipment, MemberDomain member, TimeSlotDomain timeSlot)
        {
            SetId(reservationId); 
            SetDate(date);
            SetEquipment(equipment);
            SetMember(member);
            SetTimeSlot(timeSlot);
        }

        public ReservationDomain(DateOnly date, EquipmentDomain equipment, MemberDomain member, TimeSlotDomain timeSlot)
        {
            SetDate(date);
            SetEquipment(equipment);
            SetMember(member);
            SetTimeSlot(timeSlot);
        }

        #endregion

        #region Fields

        public int ReservationId { get; set; }

        public DateOnly Date { get; set; }

        public EquipmentDomain Equipment { get; set; } = null!;

        public MemberDomain Member { get; set; } = null!;

        public TimeSlotDomain TimeSlot { get; set; } = null!;

        #endregion

        #region Methods

        public void SetId(int id)
        {
            if (id <= 0)
            {
                ReservationDomainException ex = new ReservationDomainException("Id is incorrect");
                ex.Data.Add("id", id);
                throw ex;
            }

            ReservationId = id;
        }

        public void SetDate(DateOnly date)
        {
            Date = date;
        }

        public void SetEquipment(EquipmentDomain equipment)
        {
            if (equipment == null) throw new ReservationDomainException("Equipment is empty");
            if (equipment == Equipment) throw new ReservationDomainException("Equipment already set");
            Equipment = equipment;
        }

        public void SetMember(MemberDomain member)
        {
            if (member == null) throw new ReservationDomainException("Member is empty");
            if (member == Member) throw new ReservationDomainException("Member already set");
            Member = member;
        }

        public void SetTimeSlot(TimeSlotDomain timeSlot)
        {
            if (timeSlot == null) throw new ReservationDomainException("TimeSlot is empty");
            if (timeSlot == TimeSlot) throw new ReservationDomainException("TimeSlot already set");
            TimeSlot = timeSlot;
        }

        #endregion
    }
}