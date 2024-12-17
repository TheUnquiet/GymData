using Assembly.Data.Exceptions.Mappers;
using Assembly.Data.Models;
using Assembly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Data.Mappers
{
    public static class EquipmentMapper
    {
        public static EquipmentDomain MapToDomain(Equipment equipment)
        {
            try
            {
                return new EquipmentDomain(equipment.EquipmentId, equipment.DeviceType);
            }
            catch (Exception ex)
            {
                throw new MapException($"MapToDomain, {ex}");
            }
        }

        public static Equipment MapFromDomain(EquipmentDomain domain)
        {
            try
            {
                return new Equipment()
                {
                    EquipmentId = domain.EquipmentId,
                    DeviceType = domain.DeviceType.ToString(),
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"MapFromDomain, {ex}");
            }
        }
    }
}
