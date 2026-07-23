using Fawry_Quantum_Radar.Enums;
using Fawry_Quantum_Radar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Quantum_Radar.Rules
{
    public class TruckSpeedRule : SpeedRule
    {
        protected override CarType CarType => CarType.Truck;
        protected override int MaxSpeed => 60;
        protected override decimal Fee => 300;
    }
}
