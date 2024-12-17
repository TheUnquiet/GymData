using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Assembly.Rest.Dto.Output
{
    public class EquipmentOutputDto
    {
        public int Id { get; set; }

        public string DeviceType { get; set; } = "";
    }
}
