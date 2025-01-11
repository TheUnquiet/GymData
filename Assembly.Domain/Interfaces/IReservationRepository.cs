using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<ReservationDomain>> GetAll();

        Task<ReservationDomain> GetReservationById(int id);

        Task<bool> ExistingReservation(DateOnly reservationDate, List<TimeSlotDomain> timeSlots);

        Task AddReservation(ReservationDomain reservation);

        void UpdateReservation(ReservationDomain reservation);

        void DeleteReservation(ReservationDomain reservation);
    }
}
