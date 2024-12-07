using Assembly.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Assembly.Rest.Dto.Input
{
    public class EquipmentInputDto
    {
        public DeviceTypeDomain DeviceType { get; set; }
    }
}
