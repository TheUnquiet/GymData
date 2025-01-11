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
                   .Include(r => r.Member)
                   .Where(r => r.ReservationId == id)
                   .AsNoTracking()
                   .FirstOrDefaultAsync();

                var reservationTimeSlotEquipments = await _context.ReservationTimeSlotEquipments
            .Where(rts => rts.ReservationId == id)
            .ToListAsync();

                var timeSlots = await _context.TimeSlots
                    .Where(ts => reservationTimeSlotEquipments.Select(rts => rts.TimeSlotId).Contains(ts.TimeSlotId))
                    .ToListAsync();

                var equipment = await _context.Equipment
                    .Where(eq => reservationTimeSlotEquipments.Select(rts => rts.EquipmentId).Contains(eq.EquipmentId))
                    .ToListAsync();

                // Map to domain model
                var reservationDomain = ReservationMapper.MapToDomain(reservation);

                foreach (var timeSlot in timeSlots)
                {
                    reservationDomain.AddTimeSlot(TimeSlotMapper.MapToDomain(timeSlot));
                }

                foreach (var eq in equipment)
                {
                    reservationDomain.AddEquipment(EquipmentMapper.MapToDomain(eq));
                }

                return reservationDomain;
            }
            catch (Exception ex)
            {
                throw new ReservationRepositoryException($"GetReservationById: {ex.Message}", ex);
            }
        }

        public async Task<ReservationDomain> GetReservationWithoutMember(int id)
        {
            try
            {
                var reservation = await _context.Reservations
                    .Where(r => r.ReservationId == id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var reservationTimeSlotEquipments = await _context.ReservationTimeSlotEquipments
                    .Where(rts => rts.ReservationId == id)
                    .ToListAsync();

                var timeSlots = await _context.TimeSlots
                    .Where(ts => reservationTimeSlotEquipments.Select(rts => rts.TimeSlotId).Contains(ts.TimeSlotId))
                    .ToListAsync();

                var equipment = await _context.Equipment
                    .Where(eq => reservationTimeSlotEquipments.Select(rts => rts.EquipmentId).Contains(eq.EquipmentId))
                    .ToListAsync();

                // Map to domain model
                var reservationDomain = ReservationMapper.MapToDomain(reservation);

                foreach (var timeSlot in timeSlots)
                {
                    reservationDomain.AddTimeSlot(TimeSlotMapper.MapToDomain(timeSlot));
                }

                foreach (var eq in equipment)
                {
                    reservationDomain.AddEquipment(EquipmentMapper.MapToDomain(eq));
                }

                return reservationDomain;
            }
            catch (Exception ex)
            {
                throw new ReservationRepositoryException($"GetReservationForMemberWithoutMember: {ex.Message}", ex);
            }
        }

        public async Task<bool> ExistingReservation(DateOnly reservationDate, List<TimeSlotDomain> timeSlots)
        {
            try
            {
                var timeSlotIds = timeSlots.Select(ts => ts.TimeSlotId).ToList();

                var conflictingReservation = await _context.Reservations
                    .Where(r => r.Date == reservationDate)
                    .Where(r => r.ReservationTimeSlotEquipments
                        .Any(rts => timeSlotIds.Contains(rts.TimeSlotId)))
                    .FirstOrDefaultAsync();

                return conflictingReservation != null;
            }
            catch (Exception ex)
            {
                throw new ReservationRepositoryException($"ExistingReservation: {ex.Message}", ex);
            }
        }

        public async Task AddReservation(ReservationDomain reservation)
        {
            try
            {
                // Ensure no other reservation exists with the same date and timeslot
                var conflictingReservation = await _context.Reservations
                    .Where(r => r.Date == reservation.Date &&
                                r.ReservationTimeSlotEquipments.Any(rts => reservation.TimeSlots.Any(ts => ts.TimeSlotId == rts.TimeSlotId)))
                    .FirstOrDefaultAsync();

                if (conflictingReservation != null)
                {
                    throw new ReservationRepositoryException("A reservation already exists with the same time slot on the same date.");
                }

                var reservationDb = ReservationMapper.MapFromDomain(reservation);
                await _context.Reservations.AddAsync(reservationDb);
                await _context.SaveChangesAsync();

                foreach (var timeSlot in reservation.TimeSlots)
                {
                    foreach (var equipment in reservation.Equipment)
                    {
                        // Check if this combination already exists in the ReservationTimeSlotEquipment table
                        var existingEntity = await _context.ReservationTimeSlotEquipments
                            .FirstOrDefaultAsync(rts => rts.ReservationId == reservationDb.ReservationId &&
                                                         rts.TimeSlotId == timeSlot.TimeSlotId &&
                                                         rts.EquipmentId == equipment.EquipmentId);

                        if (existingEntity == null)
                        {
                            // Only add if the combination doesn't exist
                            var reservationTimeSlotEquipment = new ReservationTimeSlotEquipment
                            {
                                ReservationId = reservationDb.ReservationId,
                                TimeSlotId = timeSlot.TimeSlotId,
                                EquipmentId = equipment.EquipmentId
                            };

                            await _context.ReservationTimeSlotEquipments.AddAsync(reservationTimeSlotEquipment);
                        }
                    }
                }

                await _context.SaveChangesAsync();
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
                _context.SaveChanges();
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
                foreach (var reservationTimeSlotEquipment in reservationDb.ReservationTimeSlotEquipments)
                {
                    var existingEntity = _context.ReservationTimeSlotEquipments
                        .Local
                        .FirstOrDefault(r => r.ReservationId == reservationTimeSlotEquipment.ReservationId &&
                                             r.TimeSlotId == reservationTimeSlotEquipment.TimeSlotId &&
                                             r.EquipmentId == reservationTimeSlotEquipment.EquipmentId);

                    if (existingEntity != null)
                    {
                        _context.Entry(existingEntity).State = EntityState.Detached;
                    }
                }

                // Detach any existing entity with the same ReservationId that may be tracked
                var existingReservation = _context.Reservations
                    .Local
                    .FirstOrDefault(r => r.ReservationId == reservationDb.ReservationId);

                if (existingReservation != null)
                {
                    _context.Entry(existingReservation).State = EntityState.Detached;
                }

                // Attach and remove the reservation entity
                _context.Reservations.Attach(reservationDb);
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
