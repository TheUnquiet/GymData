using Assembly.Domain.Exceptions.Managers;
using Assembly.Domain.Interfaces;
using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Managers
{
    public class EquipmentManager
    {
        private readonly IEquipmentRepository _repo;

        public EquipmentManager(IEquipmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<EquipmentDomain>> GetAll()
        {
            try
            {
                return await _repo.GetAll();
            }
            catch (Exception ex)
            {
                throw new EquipmentManagerException($"GetAll {ex.Message}");
            }
        }

        public async Task<EquipmentDomain> GetEquipmentById(int id)
        {
            try
            {
                return await _repo.GetEquipmentById(id);
            }
            catch (Exception ex)
            {
                throw new EquipmentManagerException($"GetEquipmentById {ex.Message}");
            }
        }

        public async Task AddEquipment(EquipmentDomain equipment)
        {
            try
            {
                await _repo.AddEquipment(equipment);
            }
            catch (Exception ex)
            {
                throw new EquipmentManagerException($"AddEquipment {ex.Message}");
            }
        }

        public async Task DeleteEquipment(int id)
        {
            try
            {
                var equipment = await _repo.GetEquipmentById(id);
                if (equipment != null)
                {
                    _repo.DeleteEquipment(equipment);
                }
            }
            catch (Exception ex)
            {
                throw new EquipmentManagerException($"DeleteEquipment: {ex.Message}");
            }
        }
    }
}
