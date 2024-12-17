using Assembly.Data.Data;
using Assembly.Data.Exceptions;
using Assembly.Data.Mappers;
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
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly GymContext _context;

        public EquipmentRepository(GymContext ctx)
        {
            _context = ctx;
        }

        public async Task<List<EquipmentDomain>> GetAll()
        {
            try
            {
                return await _context.Equipment.Select(e => EquipmentMapper.MapToDomain(e)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new EquipmentRepositoryException($"GetAll {ex.Message}");
            }
        }

        public async Task<EquipmentDomain> GetEquipmentById(int id)
        {
            try
            {
                var equipment = await _context.Equipment.Where(e => e.EquipmentId == id).AsNoTracking().FirstOrDefaultAsync();

                if (equipment != null) return EquipmentMapper.MapToDomain(equipment);

                else throw new EquipmentRepositoryException("Equipment not found");
            }
            catch (Exception ex)
            {
                throw new EquipmentRepositoryException($"GetEquipmentById {ex.Message}");
            }
        }

        public async Task AddEquipment(EquipmentDomain equipment)
        {
            try
            {
                var equipmentDb = EquipmentMapper.MapFromDomain(equipment);
                await _context.Equipment.AddAsync(equipmentDb);
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new EquipmentRepositoryException($"AddEquipment {ex.Message}");
            }
        }

        public void DeleteEquipment(EquipmentDomain equipment)
        {
            try
            {
                var equipmentDb = EquipmentMapper.MapFromDomain(equipment);
                _context.Equipment.Remove(equipmentDb);
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new EquipmentRepositoryException($"DeleteEquipment {ex.Message}");
            }
        }

        private void SaveAndClear()
        {
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}
