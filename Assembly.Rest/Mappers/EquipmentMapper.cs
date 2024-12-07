using Assembly.Domain.Models;
using Assembly.Rest.Dto.Input;
using Assembly.Rest.Dto.Output;

namespace Assembly.Rest.Mappers
{
    public static class EquipmentMapper
    {
        public static EquipmentDomain MapFromInputDto(EquipmentInputDto dto)
        {
            return new EquipmentDomain(dto.DeviceType);
        }

        public static EquipmentOutputDto MapToOutputDto(EquipmentDomain domain)
        {
            return new EquipmentOutputDto()
            {
                DeviceType = domain.DeviceType,
            };
        }
    }
}
