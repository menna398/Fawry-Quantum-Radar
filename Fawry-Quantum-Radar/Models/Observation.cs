using Fawry_Quantum_Radar.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Quantum_Radar.Models
{
    public class Observation
    {
        public string PlateNumber { get; set; } = default!;

        public DateTime Date { get; set; }

        public CarType CarType { get; set; }

        public int Speed { get; set; }

        public bool SeatbeltFastened { get; set; }
    }
}
