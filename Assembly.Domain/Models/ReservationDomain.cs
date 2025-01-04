using Assembly.Domain.Exceptions;

namespace Assembly.Domain.Models
{
    public class ReservationDomain
    {
        #region Constructors

        public ReservationDomain(int reservationId, DateOnly date, MemberDomain member, List<TimeSlotDomain> timeSlots, List<EquipmentDomain> equipment)
        {
            SetId(reservationId); 
            SetDate(date);
            SetMember(member);

            foreach (var slot in timeSlots)
            {
                AddTimeSlot(slot);
            }

            foreach (var e in equipment)
            {
                AddEquipment(e);
            }
        }

        public ReservationDomain(DateOnly date, MemberDomain member, List<TimeSlotDomain> timeSlots, List<EquipmentDomain> equipment)
        {
            SetDate(date);
            SetMember(member);
            foreach (var slot in timeSlots)
            {
                AddTimeSlot(slot);
            }

            foreach (var e in equipment)
            {
                AddEquipment(e);
            }
        }

        #endregion

        #region Fields

        public int ReservationId { get; set; }

        public DateOnly Date { get; set; }

        public MemberDomain Member { get; set; } = null!;

        public List<TimeSlotDomain> TimeSlots { get; } = [];

        public List<EquipmentDomain> Equipment { get; } = [];

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

            if (date > DateOnly.FromDateTime(DateTime.Now).AddDays(7))
            {
                throw new ReservationDomainException($"Date out of bounds");
            }
        }

        public void SetMember(MemberDomain member)
        {
            if (member == null) throw new ReservationDomainException("Member is empty");
            if (member == Member) throw new ReservationDomainException("Member already set");
            Member = member;
        }

        public void AddEquipment(EquipmentDomain equipment)
        {
            if (equipment == null) throw new ReservationDomainException($"Equipment empty");
            if (Equipment.Contains(equipment)) throw new ReservationDomainException($"Equipment already added");
            Equipment.Add(equipment);
        }

        public void AddTimeSlot(TimeSlotDomain timeSlot)
        {
            if (timeSlot == null) throw new ReservationDomainException($"TimeSlot empty");
            if (TimeSlots.Contains(timeSlot)) throw new ReservationDomainException($"TimeSlot already added");
            TimeSlots.Add(timeSlot);
        }

        #endregion
    }
}