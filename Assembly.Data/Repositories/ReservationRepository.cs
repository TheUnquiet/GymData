using Assembly.Data.Data;
using Assembly.Data.Exceptions;
using Assembly.Data.Mappers;
using Assembly.Data.Models;
using Assembly.Domain.Interfaces;
using Assembly.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly GymContext _context;

        public ReservationRepository(GymContext context)
        {
            _context = context;
        }

        public async Task<List<ReservationDomain>> GetAll()
        {
            try
            {
                return await _context.Reservations.Select(r => ReservationMapper.MapToDomain(r)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ReservationRepositoryException($"GetAll: {ex.Message}", ex);
            }
        }

        public async Task<ReservationDomain> GetReservationById(int id)
        {
            try
            {
                var reservation = await _context.Reservations
                    .Include(r => r.TimeSlot)
                    .Include(r => r.Member)
                    .Include(r => r.Equipment)
                    .Where(r => r.ReservationId == id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (reservation != null) return ReservationMapper.MapToDomain(reservation);

                else throw new ReservationRepositoryException("Reservation empty");
            }
            catch (Exception ex)
            {
                throw new ReservationRepositoryException($"GetReservationById: {ex.Message}", ex);
            }
        }

        public async Task AddReservation(ReservationDomain reservation)
        {
            try
            {
                var reservationDb = ReservationMapper.MapFromDomain(reservation);
                await _context.Reservations.AddAsync(reservationDb);
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new ReservationRepositoryException($"AddReservation: {ex.Message}", ex);
            }
        }

        public void UpdateReservation(ReservationDomain reservation)
        {
            try
            {
                var reservationDb = ReservationMapper.MapFromDomain(reservation);
                    
                _context.Reservations.Update(reservationDb);
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new ReservationRepositoryException($"UpdateReservation: {ex.Message}", ex);
            }
        }

        public void DeleteReservation(ReservationDomain reservation)
        {
            try
            {
                var reservationDb = ReservationMapper.MapFromDomain(reservation);
                _context.Reservations.Remove(reservationDb);
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new ReservationRepositoryException($"DeleteReservation: {ex.Message}", ex);
            }
        }

        private void SaveAndClear()
        {
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}
