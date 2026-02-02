using System.Collections.Generic;

namespace StreamBuzz
{
    /// <summary>
    /// Stores creator engagement statistics.
    /// </summary>
    public class CreatorStats
    {
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }

        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
    }
}
