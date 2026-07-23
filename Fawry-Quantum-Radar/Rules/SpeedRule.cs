using Fawry_Quantum_Radar.Enums;
using Fawry_Quantum_Radar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Quantum_Radar.Rules
{
    public abstract class SpeedRule : IRule
    {
        // abstract class for all speed validation rules.
        // Allows adding new vehicle speed rules without duplicating the code.
        protected abstract CarType CarType { get; }
        protected abstract int MaxSpeed { get; }
        protected abstract decimal Fee { get; }

        public Violation? Check(Observation observation)
        {
            if (observation is null)
                throw new ArgumentNullException(nameof(observation));

            if (observation.CarType != CarType)
                return null;

            if (observation.Speed <= MaxSpeed)
                return null;

            return new Violation
            {
                RuleName = GetType().Name,
                Description = $"Speed of {observation.Speed} exceeded max allowed {MaxSpeed}",
                Fee = Fee
            };
        }
    }
}
