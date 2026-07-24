using Fawry_Quantum_Radar.Models;
using Fawry_Quantum_Radar.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Quantum_Radar.Services
{
    public class QuRadar
    {
        private readonly List<IRule> _rules;
        private readonly List<Fine> _fines = new();

        public QuRadar(List<IRule> rules)
        {
            _rules = rules;
        }

        public Fine? ProcessObservation(Observation observation)
        {
            if (observation is null)
                throw new ArgumentNullException(nameof(observation));

            List<Violation> violations = new();

            foreach (var rule in _rules)
            {
                var violation = rule.Check(observation);

                if (violation != null)
                {
                    violations.Add(violation);
                }
            }

            if (!violations.Any())
                return null;

            var fine = new Fine
            {
                PlateNumber = observation.PlateNumber,
                Violations = violations
            };

            _fines.Add(fine);

            return fine;
        }

        public List<Fine> GetAllPossibleFines()
        {
            return _fines;
        }

        public Dictionary<string, int> GetViolatedRulesCount()
        {
            return _fines
                .SelectMany(f => f.Violations)
                .GroupBy(v => v.RuleName)
                .ToDictionary(
                    group => group.Key,
                    group => group.Count());
        }
    }
}
