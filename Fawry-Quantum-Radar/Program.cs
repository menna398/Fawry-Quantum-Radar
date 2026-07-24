using Fawry_Quantum_Radar.Enums;
using Fawry_Quantum_Radar.Models;
using Fawry_Quantum_Radar.Rules;
using Fawry_Quantum_Radar.Services;

namespace Fawry_Quantum_Radar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Register Rules
            List<IRule> rules = new()
            {
                new SeatbeltRule(),
                new PrivateSpeedRule(),
                new TruckSpeedRule()
            };

            // Create Radar
            QuRadar radar = new QuRadar(rules);

            // Create Observations
            List<Observation> observations = new()
            {
                new Observation
                {
                    PlateNumber = "ABC1234",
                    Date = DateTime.Now,
                    CarType = CarType.Private,
                    Speed = 94,
                    SeatbeltFastened = false
                },

                new Observation
                {
                    PlateNumber = "EFG5678",
                    Date = DateTime.Now,
                    CarType = CarType.Truck,
                    Speed = 75,
                    SeatbeltFastened = true
                },

                new Observation
                {
                    PlateNumber = "HIJ9832",
                    Date = DateTime.Now,
                    CarType = CarType.Private,
                    Speed = 70,
                    SeatbeltFastened = false
                },

                new Observation
                {
                    PlateNumber = "SAFE111",
                    Date = DateTime.Now,
                    CarType = CarType.Private,
                    Speed = 70,
                    SeatbeltFastened = true
                }
            };

            Console.WriteLine("========== Traffic Fines ==========\n");

            foreach (var observation in observations)
            {
                Fine? fine = radar.ProcessObservation(observation);

                if (fine == null)
                    continue;

                Console.WriteLine($"Traffic fine for car {fine.PlateNumber}");
                Console.WriteLine($"Total amount: {fine.TotalAmount} EGP");
                Console.WriteLine("Violations:");

                foreach (var violation in fine.Violations)
                {
                    Console.WriteLine($"- {violation.Description} : {violation.Fee} EGP");
                }

                Console.WriteLine();
            }

            Console.WriteLine("====================================");
            Console.WriteLine("Get All Possible Fines");
            Console.WriteLine("====================================");

            foreach (var fine in radar.GetAllPossibleFines())
            {
                Console.WriteLine($"{fine.PlateNumber} -> {fine.TotalAmount} EGP");
            }

            Console.WriteLine();

            Console.WriteLine("====================================");
            Console.WriteLine("Get All Violated Rules Count");
            Console.WriteLine("====================================");

            foreach (var rule in radar.GetViolatedRulesCount())
            {
                Console.WriteLine($"{rule.Key} -> {rule.Value}");
            }

            Console.ReadKey();
        }
    }
}
