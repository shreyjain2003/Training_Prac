using System;

namespace FactoryRobotHazardAnalyzer
{
    /// <summary>
    /// Responsible for calculating robot hazard risk.
    /// </summary>
    public class RobotHazardAuditor
    {
        /// <summary>
        /// Calculates hazard risk score based on precision, density and machinery state.
        /// </summary>
        public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
        {
            if (armPrecision < 0.0 || armPrecision > 1.0)
                throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");

            if (workerDensity < 1 || workerDensity > 20)
                throw new RobotSafetyException("Error: Worker density must be 1-20");

            double machineRiskFactor;

            switch (machineryState)
            {
                case "Worn":
                    machineRiskFactor = 1.3;
                    break;
                case "Faulty":
                    machineRiskFactor = 2.0;
                    break;
                case "Critical":
                    machineRiskFactor = 3.0;
                    break;
                default:
                    throw new RobotSafetyException("Error: Unsupported machinery state");
            }

            return ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);
        }
    }
}
