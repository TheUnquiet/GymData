using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Domain.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<EquipmentDomain> GetEquipmentById(int id);

        Task<List<EquipmentDomain>> GetAll();

        Task AddEquipment(EquipmentDomain equipment);

        void DeleteEquipment(EquipmentDomain equipment);
    }
}
