using Fawry_Quantum_Radar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Quantum_Radar.Rules
{
    public interface IRule
    {
        public Violation? Check(Observation observation); //nullable
    }
}
