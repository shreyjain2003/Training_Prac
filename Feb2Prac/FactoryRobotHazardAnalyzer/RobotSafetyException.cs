using System;

namespace FactoryRobotHazardAnalyzer
{
    /// <summary>
    /// Custom exception used for robot safety validation errors.
    /// </summary>
    public class RobotSafetyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of RobotSafetyException with a custom message.
        /// </summary>
        public RobotSafetyException(string message) : base(message)
        {
        }
    }
}
