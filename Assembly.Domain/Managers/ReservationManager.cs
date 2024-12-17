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
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMemberRepository _memberRepository;

        public ReservationManager(IReservationRepository repo, IEquipmentRepository equipmentRepository, IMemberRepository memberRepository)
        {
            _reservationRepository = repo;
            _equipmentRepository = equipmentRepository;
            _memberRepository = memberRepository;
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

        public async Task AddReservation(ReservationDomain reservation)
        {
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

        public void DeleteReservation(ReservationDomain reservation)
        {
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
