using Fawry_Quantum_Radar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Quantum_Radar.Rules
{
    public class SeatbeltRule : IRule
    {
        public Violation? Check(Observation observation)
        {
            if(observation.SeatbeltFastened) 
                return null;

            return new Violation
            {
                RuleName = "SeatbeltRule",
                Description = "Seatbelt not fastened",
                Fee = 100
            };

        }
    }
}
