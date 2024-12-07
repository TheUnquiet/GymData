using Assembly.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Assembly.Rest.Dto.Output
{
    public class EquipmentOutputDto
    {
        // https://stackoverflow.com/questions/41740638/using-enum-for-dropdown-list-in-asp-net-mvc-core
        [EnumDataType(typeof(DeviceTypeDomain))]
        public DeviceTypeDomain DeviceType { get; set; }
    }
}
