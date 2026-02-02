using System;

namespace FactoryRobotHazardAnalyzer
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
                double precision = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Worker Density (1 - 20):");
                int density = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
                string state = Console.ReadLine();

                RobotHazardAuditor auditor = new RobotHazardAuditor();
                double risk = auditor.CalculateHazardRisk(precision, density, state);

                Console.WriteLine($"Robot Hazard Risk Score: {risk}");
            }
            catch (RobotSafetyException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
