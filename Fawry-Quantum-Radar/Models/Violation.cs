using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Quantum_Radar.Models
{
    public class Violation
    {
        public string Description { get; set; } = default!;

        public decimal Fee { get; set; }

        public string RuleName { get; set; } = default!;
    }
}
