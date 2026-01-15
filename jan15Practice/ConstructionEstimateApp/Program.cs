using System;

namespace ConstructionEstimateApp
{
    /// <summary>
    /// Custom exception for construction estimate validation.
    /// </summary>
    public class ConstructionEstimateException : Exception
    {
        public ConstructionEstimateException(string message) : base(message)
        {

        }
    }

    /// <summary>
    /// Main program class for construction estimate validation.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Validates the construction estimate.
        /// Throws ConstructionEstimateException if ConstructionArea exceeds SiteArea.
        /// </summary>
        public EstimateDetails ValidateConstructionEstimate(float ConstructionArea, float SiteArea)
        {
            if(ConstructionArea > SiteArea)
            {
                throw new ConstructionEstimateException("Sorry your Construction Estimate is not approved");
            }
            return new EstimateDetails
            {
                ConstructionArea=ConstructionArea,
                SiteArea=SiteArea
            };
        }
        public static void Main(string[] args)
        {
            Program p=new Program();
            try
            {
                EstimateDetails ed=p.ValidateConstructionEstimate(500,400);
                Console.WriteLine("Construction Area: "+ed.ConstructionArea);
                Console.WriteLine("Site Area: "+ed.SiteArea);
                Console.WriteLine("Construction Estimate Approved");
            }
            catch(ConstructionEstimateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}