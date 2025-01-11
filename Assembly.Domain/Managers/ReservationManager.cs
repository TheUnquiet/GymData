using Assembly.Domain.Exceptions.Managers;
using Assembly.Domain.Interfaces;
using Assembly.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Managers
{
    public class ReservationManager
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationManager(IReservationRepository repo)
        {
            _reservationRepository = repo;
        }

        public async Task<List<ReservationDomain>> GetAll()
        {
            try
            {
                return await _reservationRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ReservationManagerException($"GetAll: {ex.Message}", ex);
            }
        }

        public async Task<ReservationDomain> GetReservationById(int id)
        {
            try
            {
               return await _reservationRepository.GetReservationById(id);
            }
            catch (Exception ex)
            {
                throw new ReservationManagerException($"GetReservationById: {ex.Message}", ex);
            }
        }

        public async Task<bool> ExistingReservation(DateOnly reservationDate, List<TimeSlotDomain> timeSlots)
        {
            try
            {
                return await _reservationRepository.ExistingReservation(reservationDate, timeSlots);
            }
            catch (Exception ex)
            {
                throw new ReservationManagerException($"ExistingReservation: {ex.Message}", ex);
            }
        }

        public async Task AddReservation(ReservationDomain reservation)
        {
            if (await ExistingReservation(reservation.Date, reservation.TimeSlots)) throw new ReservationManagerException("A reservation already exists with the same time slot on the same date.");

            try
            {
               await _reservationRepository.AddReservation(reservation);
            }
            catch (Exception ex)
            {
                throw new ReservationManagerException($"AddReservation: {ex.Message}", ex);
            }
        }

        public void UpdateReservation(ReservationDomain reservation)
        {
            try
            {
               _reservationRepository.UpdateReservation(reservation);
            }
            catch (Exception ex)
            {
                throw new ReservationManagerException($"UpdateReservation: {ex.Message}", ex);
            }
        }

        public async Task DeleteReservation(ReservationDomain reservation)
        {
            if (await GetReservationById(reservation.ReservationId) == null) throw new ReservationManagerException("Reservation does not exist.");

            try
            {
                _reservationRepository.DeleteReservation(reservation);
            }
            catch (Exception ex)
            {
                throw new ReservationManagerException($"DeleteReservation: {ex.Message}", ex);
            }
        }
    }
}
