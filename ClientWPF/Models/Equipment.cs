using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.WPF.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public string PartOfDay { get; set; } = "";

        public override string ToString()
        {
            return $"{Id} {PartOfDay}";
        }
    }
}
