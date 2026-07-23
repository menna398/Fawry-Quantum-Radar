using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Quantum_Radar.Models
{
    public class Fine
    {
        public string PlateNumber { get; set; } = default!;

        public List<Violation> Violations { get; set; } = new();

        public decimal TotalAmount => Violations.Sum(v => v.Fee);
    }
}
